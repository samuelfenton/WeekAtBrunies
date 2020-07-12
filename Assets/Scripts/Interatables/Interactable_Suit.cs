using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Suit : Interactable
{

    public Mesh m_suitMesh = null;
    public Material m_suitMaterial = null;

    public override void UseInteractable()
    {
        if(m_suitMesh != null && m_suitMaterial != null)
        {
            SkinnedMeshRenderer meshRenderer = m_gameController.m_brunie.GetComponentInChildren<SkinnedMeshRenderer>();
            meshRenderer.sharedMesh = m_suitMesh;
            meshRenderer.material = m_suitMaterial;
        }

        m_worldState.SetWorldState(WorldState.WORLD_STATES.HAS_SUIT, true);

        DisableInteractable();
        Destroy(gameObject);
    }

    public override bool CanUseInteractable()
    {
        return m_gameController.m_NPC.m_grabbedEnity == m_gameController.m_brunie;
    }
}

