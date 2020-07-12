using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [HideInInspector]
    public const float GRAB_FORCE = 100.0f;
    [HideInInspector]
    public const float GRAB_DISTANCE = 1.0f;

    public GameObject m_grabPoint = null;
    public GameObject m_movementBody = null;

    protected GameController m_gameController = null;
    protected WorldState m_worldState = null;
    protected Rigidbody m_grabRB = null;
    protected Rigidbody m_movementRB = null;

    public virtual void InitEntity(GameController p_gameController)
    {
        m_gameController = p_gameController;
        m_worldState = m_gameController.GetComponent<WorldState>();

        if (m_grabPoint!= null)
            m_grabRB = m_grabPoint.GetComponent<Rigidbody>();
        if (m_movementBody != null)
            m_movementRB = m_movementBody.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Update the entity, same time as update. Should be called by gamecontroller
    /// </summary>
    public virtual void UpdateEntity()
    {

    }

    /// <summary>
    /// Entity has been grabbed, move towards point
    /// </summary>
    /// <param name="p_position"></param>
    public void GrabbedEntity(Vector3 p_position)
    {
        Vector3 grabPointToDestination = p_position - m_grabPoint.transform.position;
        m_grabRB.AddForce(grabPointToDestination * GRAB_FORCE, ForceMode.Acceleration);
    }
}
