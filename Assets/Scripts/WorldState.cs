using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState : MonoBehaviour
{
    public enum WORLD_STATES {HAS_SUIT, NA}

    private bool[] m_worldStates = new bool[(int)WORLD_STATES.NA];

    private void Start()
    {
        for (int worldStateIndex = 0; worldStateIndex < (int)WORLD_STATES.NA; worldStateIndex++)
        {
            m_worldStates[worldStateIndex] = false;
        }
    }

    public void SetWorldState(WORLD_STATES p_worldState, bool p_val)
    {
        m_worldStates[(int)p_worldState] = p_val;
    }

    public bool GetWorldState(WORLD_STATES p_worldState)
    {
        return m_worldStates[(int)p_worldState];
    }
}
