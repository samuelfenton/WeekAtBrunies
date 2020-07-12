using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : Entity
{
    public GameObject m_UIElement = null;
    private TextMeshProUGUI m_text = null;
    public override void InitEntity(GameController p_gameController)
    {
        base.InitEntity(p_gameController);

        if (m_UIElement != null)
        {
            m_text = m_UIElement.GetComponentInChildren<TextMeshProUGUI>();
            m_UIElement.SetActive(false);
        }
    }

    /// <summary>
    /// Update the entity, same time as update. Should be called by gamecontroller
    /// </summary>
    public override void UpdateEntity()
    {

    }

    private void OnMouseEnter()
    {
        if(m_UIElement != null)
        {
            m_UIElement.SetActive(true);
            if (m_text != null)
                m_text.color = CanUseInteractable() ? Color.white : Color.red;

        }

    }

    private void OnMouseExit()
    {
        if (m_UIElement != null)
            m_UIElement.SetActive(false);
    }


    private void OnMouseDown()
    {
        if(CanUseInteractable())
            m_gameController.m_NPC.SetTargetInteractable(this);
    }

    public virtual void UseInteractable()
    {

    }

    public virtual bool CanUseInteractable()
    {
        return false;
    }

    /// <summary>
    /// Use to stop interactable being in use
    /// </summary>
    public void DisableInteractable()
    {
        if (m_UIElement != null)
            m_UIElement.SetActive(false);

        Destroy(this);
    }

}
