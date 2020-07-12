using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    /// <summary>
    /// Init state, only happens once
    /// </summary>    
    public virtual void InitState()
    {

    }

    /// <summary>
    /// Start State, runs everytime a state starts
    /// </summary>
    public virtual void StartState()
    {

    }

    /// <summary>
    /// Updates a given state, returns true when completed
    /// </summary>
    /// <returns></returns>
    public virtual bool UpdateState()
    {
        return true;
    }

    /// <summary>
    /// States ends
    /// </summary>
    public virtual void EndState()
    {

    }

    /// <summary>
    /// Is this a valid state
    /// </summary>
    public virtual bool IsValid()
    {
        return false;
    }
}
