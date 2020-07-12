using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Door : Interactable
{
    public WorldState.WORLD_STATES m_requiredWorldState = WorldState.WORLD_STATES.NA;
    public GameObject m_door = null;

    public List<WallSection> m_toggledWalls = new List<WallSection>();

    public override void UseInteractable()
    {
        if(m_door != null)
            m_door.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f), Space.Self);

        foreach (WallSection wallSelection in m_toggledWalls)
        {
            wallSelection.ToggleVisibility();
        }

        DisableInteractable();
    }

    public override bool CanUseInteractable()
    {
        return m_gameController.m_NPC.m_grabbedEnity == m_gameController.m_brunie && m_worldState.GetWorldState(m_requiredWorldState);
    }
}
