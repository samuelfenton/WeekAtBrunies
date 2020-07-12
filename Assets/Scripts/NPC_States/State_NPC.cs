using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_NPC : State
{
    protected Entity_NPC m_NPC = null;
    protected Entity_Brunie m_brunie = null;

    /// <summary>
    /// Init state, only happens once
    /// </summary>
    public override void InitState()
    {
        base.InitState();

        m_NPC = GetComponent<Entity_NPC>();
        m_brunie = FindObjectOfType<Entity_Brunie>();
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
        return true;
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
        return false;
    }
}
