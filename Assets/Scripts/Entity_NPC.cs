using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_NPC : Entity
{
    public enum POSSIBLE_COMMANDS {IDLE, PICK_UP, DROP, GO_TO_INTERACTABLE, GO_TO_POINT, COUNT}

    [HideInInspector]
    public Entity m_grabbedEnity = null;

    public GameObject m_model = null;

    [Header("Assigned Body Parts")]
    public GameObject m_rightArm = null;
    public GameObject m_leftArm = null;
    public GameObject m_rightFoot = null;
    public GameObject m_leftFoot = null;

    private Rigidbody m_rightFootRB = null;
    private Rigidbody m_leftFootRB = null;

    [Header("Assigned Leg Varibles")]
    public float m_legSwingTime = 2.0f;
    public float m_legSwingForce = 2.0f;
    private float m_legFrequency = 0.5f;

    [Header("Movement Stats")]
    public float m_forwardSpeed = 10.0f;
    public float m_turningIntensity = 30.0f;

    [Header("Idle Varibles")]
    [Tooltip("Degrees around itll try to rotate")]
    public float m_turningErraticness = 80.0f;

    private State_NPC[] m_possibleStates = new State_NPC[(int)POSSIBLE_COMMANDS.COUNT];
    private POSSIBLE_COMMANDS m_currentCommand = POSSIBLE_COMMANDS.IDLE;

    private Entity_Brunie m_brunie = null;
    private Camera m_gameCamera = null;

    //State machien stuff
    [HideInInspector]
    public Interactable m_targetInteractable = null;
    public Vector3 m_targetPoint = Vector3.zero;

    public override void InitEntity(GameController p_gameController)
    {
        base.InitEntity(p_gameController);

        m_brunie = m_gameController.m_brunie;

        m_legFrequency = 1 / m_legSwingTime;

        if(m_rightFoot!=null)
            m_rightFootRB = m_rightFoot.GetComponent<Rigidbody>();

        if (m_leftFoot != null)
            m_leftFootRB = m_leftFoot.GetComponent<Rigidbody>();

        m_gameCamera = Camera.main;

        StateMachineInit();
    }

    /// <summary>
    /// Update the entity, same time as update. Should be called by gamecontroller
    /// </summary>
    public override void UpdateEntity()
    { 
        base.UpdateEntity();

        //Update leg swing
        Vector3 forceDir = Vector3.up * m_legSwingForce * Mathf.Sin(m_legFrequency * Time.time);

        m_rightFootRB.AddRelativeForce(forceDir, ForceMode.Acceleration);
        m_leftFootRB.AddRelativeForce(forceDir, ForceMode.Acceleration);

        if (m_grabbedEnity != null)
        {
            m_grabbedEnity.GrabbedEntity(m_rightArm.transform.position);
        }

        //Check for mouse clicks

        if(Input.GetAxis("Fire1") > 0.0f)
        {
            GroundClickCheck();
        }

        StateMachineUpdate();
    }

    /// <summary>
    /// Add a new command, and change the state
    /// </summary>
    /// <param name="p_newCommand"></param>
    public void NewCommand(POSSIBLE_COMMANDS p_newCommand)
    {
        if (p_newCommand == POSSIBLE_COMMANDS.COUNT)
            return;

        SwapStates(p_newCommand);
    }

    public void MoveTowards(Vector3 p_point, float p_speed)
    {
        Vector3 NPCToPoint = p_point - transform.position;
        NPCToPoint.y = 0.0f;

        float angle = Vector3.SignedAngle(transform.forward, NPCToPoint, Vector3.up);

        if (angle > 0.0f) //Rot right
        {
            transform.Rotate(Vector3.up, Time.deltaTime * m_turningIntensity);
        }
        else 
        {
            transform.Rotate(Vector3.up, Time.deltaTime * -m_turningIntensity);
        }

        float forwardTurningModifier = -((angle/60.0f)*(angle / 60.0f)) + 1;

        forwardTurningModifier = Mathf.Clamp(forwardTurningModifier, 0.0f, 1.0f);

        m_movementRB.velocity = transform.forward * p_speed * forwardTurningModifier;
    }

    public void SetTargetInteractable(Interactable p_target)
    {
        if(p_target != null)
        {
            m_targetInteractable = p_target;
            SwapStates(POSSIBLE_COMMANDS.GO_TO_INTERACTABLE);
        }
    }

    private void GroundClickCheck()
    {
        RaycastHit hit;
        Ray ray = m_gameCamera.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.layer == CustomLayers.m_walkable)
            {
                m_targetPoint = hit.point;
                m_targetPoint.y = 0.0f;

                SwapStates(POSSIBLE_COMMANDS.GO_TO_POINT);
            }
        }
    }

    #region STATE MACHINE
    //State machine stuff

    public void StateMachineInit()
    {
        m_possibleStates = new State_NPC[(int)POSSIBLE_COMMANDS.COUNT];

        //Setup states
        m_possibleStates[(int)POSSIBLE_COMMANDS.IDLE] = gameObject.AddComponent<StateNPC_Idle>();
        m_possibleStates[(int)POSSIBLE_COMMANDS.PICK_UP] = gameObject.AddComponent<StateNPC_GrabMe>();
        m_possibleStates[(int)POSSIBLE_COMMANDS.DROP] = gameObject.AddComponent<StateNPC_DropMe>();
        m_possibleStates[(int)POSSIBLE_COMMANDS.GO_TO_INTERACTABLE] = gameObject.AddComponent<StateNPC_GoToInteractable>();
        m_possibleStates[(int)POSSIBLE_COMMANDS.GO_TO_POINT] = gameObject.AddComponent<StateNPC_GoToPoint>();

        //init
        for (int stateIndex = 0; stateIndex < m_possibleStates.Length; stateIndex++)
        {
            m_possibleStates[stateIndex].InitState();
        }

        //Setup inital values
        m_currentCommand = POSSIBLE_COMMANDS.IDLE;

        m_possibleStates[(int)m_currentCommand].StartState();
    }

    public void StateMachineUpdate()
    {
        if(m_possibleStates[(int)m_currentCommand].UpdateState())
        {
            SwapStates(POSSIBLE_COMMANDS.IDLE);
        }
    }

    public void SwapStates(POSSIBLE_COMMANDS p_newCommmand)
    {
        if (p_newCommmand == POSSIBLE_COMMANDS.COUNT || !m_possibleStates[(int)p_newCommmand].IsValid())
            return;

        m_possibleStates[(int)m_currentCommand].EndState();

        m_currentCommand = p_newCommmand;

        m_possibleStates[(int)m_currentCommand].StartState();
    }
    #endregion
}
