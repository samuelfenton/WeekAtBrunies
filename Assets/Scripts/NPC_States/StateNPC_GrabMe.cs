using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNPC_GrabMe : State_NPC
{
    /// <summary>
    /// Init state, only happens once
    /// </summary>
    public override void InitState()
    {
        base.InitState();
    }

    /// <summary>
    /// Start State, runs everytime a state starts
    /// </summary>
    public override void StartState()
    {
        base.InitState();
    }

    /// <summary>
    /// Updates a given state, returns true when completed
    /// </summary>
    /// <returns></returns>
    public override bool UpdateState()
    {
        if (MOARMaths.CloseEnoughNoY(m_brunie.m_grabPoint.transform.position, m_NPC.transform.position, Entity.GRAB_DISTANCE))
        {
            m_NPC.m_grabbedEnity = m_brunie;
            return true;
        }

        m_NPC.MoveTowards(m_brunie.m_grabPoint.transform.position, m_NPC.m_forwardSpeed);

        return false;
    }

    /// <summary>
    /// 
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
        return m_NPC.m_grabbedEnity == null;
    }
}
