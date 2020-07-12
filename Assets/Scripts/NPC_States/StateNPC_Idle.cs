using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNPC_Idle : State_NPC
{
    private const float m_idleToDistance = 5.0f;
    private float m_idleToMaxTime = 5.0f;
    private float m_idleSpeedDivider = 2.0f;

    private GameController m_gameController = null;

    private Vector3 m_idleDestination = Vector3.zero;

    private float m_timer = 0.0f;

    /// <summary>
    /// Init state, only happens once
    /// </summary>
    public override void InitState()
    {
        base.InitState();
        m_gameController = FindObjectOfType<GameController>();

        m_idleToMaxTime = m_idleToDistance / (m_NPC.m_forwardSpeed / m_idleSpeedDivider);
    }

    /// <summary>
    /// Start State, runs everytime a state starts
    /// </summary>
    public override void StartState()
    {
        base.InitState();

        m_idleDestination.x = transform.position.x + Random.Range(-m_idleToDistance, m_idleToDistance);
        m_idleDestination.z = transform.position.z + Random.Range(-m_idleToDistance, m_idleToDistance);
        m_idleDestination.y = 0.0f;

        m_timer = m_idleToMaxTime;
    }

    /// <summary>
    /// Updates a given state, returns true when completed
    /// </summary>
    /// <returns></returns>
    public override bool UpdateState()
    {
        Vector3 NPCToPoint = m_idleDestination - m_NPC.transform.position;
        NPCToPoint.y = 0.0f;

        m_timer -= Time.deltaTime;

        if (NPCToPoint.magnitude < Entity.GRAB_DISTANCE || m_timer < -0.0f)
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
