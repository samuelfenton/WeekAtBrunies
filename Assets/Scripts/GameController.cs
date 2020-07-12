using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector2 m_arenaBounds = new Vector2(20.0f, 20.0f);
    
    private UIController m_UIController = null;
    private Entity[] m_entities;

    private void Start()
    {
        m_UIController = FindObjectOfType<UIController>();
        m_UIController.InitUI();

        m_entities = FindObjectsOfType<Entity>();

        for (int entityIndex = 0; entityIndex < m_entities.Length; entityIndex++)
        {
            m_entities[entityIndex].InitEntity(this);
        }
    }

    private void Update()
    {
        for (int entityIndex = 0; entityIndex < m_entities.Length; entityIndex++)
        {
            m_entities[entityIndex].UpdateEntity();
        }
    }
}
