using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSection : MonoBehaviour
{
    private const float TRANSPARANCY_VAL = 0.3f;

    Collider[] m_childColldiers;
    MeshRenderer[] m_childRenderers;
    private void Start()
    {
        m_childColldiers = GetComponentsInChildren<Collider>();
        m_childRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void ToggleVisibility()
    {
        for (int colldierIndex = 0; colldierIndex < m_childColldiers.Length; colldierIndex++)
        {
            m_childColldiers[colldierIndex].enabled = false;
        }

        for (int rendererIndex = 0; rendererIndex < m_childRenderers.Length; rendererIndex++)
        {
            Color matColor = m_childRenderers[rendererIndex].material.color;
            matColor.a = TRANSPARANCY_VAL;
            m_childRenderers[rendererIndex].material.color = matColor;
        }
    }

}
