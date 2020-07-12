using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{    
    private UIController m_UIController = null;
    private Entity[] m_entities;

    [HideInInspector]
    public Entity_Brunie m_brunie = null;
    [HideInInspector]
    public Entity_NPC m_NPC = null;
    [HideInInspector]
    public CameraFollow m_cameraFollow = null;

    private void Start()
    {
        m_brunie = FindObjectOfType<Entity_Brunie>();
        m_NPC = FindObjectOfType<Entity_NPC>();

        m_cameraFollow = FindObjectOfType<CameraFollow>();

        m_UIController = FindObjectOfType<UIController>();
        m_UIController.InitUI();

        m_entities = FindObjectsOfType<Entity>();

        for (int entityIndex = 0; entityIndex < m_entities.Length; entityIndex++)
        {
            m_entities[entityIndex].InitEntity(this);
        }

        enabled = false;
    }

    private void Update()
    {
        for (int entityIndex = 0; entityIndex < m_entities.Length; entityIndex++)
        {
            m_entities[entityIndex].UpdateEntity();
        }
    }
}
