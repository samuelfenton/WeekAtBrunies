using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected GameController m_gameController = null;

    public virtual void InitEntity(GameController p_gameController)
    {
        m_gameController = p_gameController;
    }

    /// <summary>
    /// Update the entity, same time as update. Should be called by gamecontroller
    /// </summary>
    public virtual void UpdateEntity()
    {

    }
}
