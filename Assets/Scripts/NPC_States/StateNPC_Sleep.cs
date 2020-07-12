using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNPC_Sleep : State_NPC
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
