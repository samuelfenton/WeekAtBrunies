using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNPC_Idle : State_NPC
{
    private GameController m_gameController = null;

    private Vector3 m_idleDestination = Vector3.zero;

    /// <summary>
    /// Init state, only happens once
    /// </summary>
    public override void InitState()
    {
        base.InitState();
        m_gameController = FindObjectOfType<GameController>();
    }

    /// <summary>
    /// Start State, runs everytime a state starts
    /// </summary>
    public override void StartState()
    {
        base.InitState();

        m_idleDestination.x = Random.Range(-m_gameController.m_arenaBounds.x, m_gameController.m_arenaBounds.x);
        m_idleDestination.z = Random.Range(-m_gameController.m_arenaBounds.y, m_gameController.m_arenaBounds.y);
        m_idleDestination.y = 0.0f;
    }

    /// <summary>
    /// Updates a given state, returns true when completed
    /// </summary>
    /// <returns></returns>
    public override bool UpdateState()
    {
        Vector3 NPCToPoint = m_idleDestination - m_NPC.transform.position;
        NPCToPoint.y = 0.0f;

        if (NPCToPoint.magnitude < m_brunie.m_grabDistance)
        {
            return true;
        }

        m_NPC.MoveTowards(m_idleDestination, m_NPC.m_forwardSpeed / 2.0f);

        return false;
    }

    /// <summary>
    /// States ends
    /// </summary>
    public override void EndState()
    {

    }

    /// <summary>
    /// Is this a valid state
    /// </summary>
    public override bool IsValid()
    {
        return true;
    }
}
