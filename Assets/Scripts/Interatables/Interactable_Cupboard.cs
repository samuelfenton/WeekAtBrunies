using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Cupboard : Interactable
{
    public GameObject m_leftDoor = null;
    public GameObject m_rightDoor = null;

    public GameObject m_secondaryInteractable = null;

    public override void InitEntity(GameController p_gameController)
    {
        base.InitEntity(p_gameController);

        if (m_secondaryInteractable != null)
            m_secondaryInteractable.SetActive(false);
    }

    public override void UseInteractable()
    {
        m_rightDoor.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f), Space.Self);
        m_leftDoor.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f), Space.Self);

        if (m_secondaryInteractable != null)
            m_secondaryInteractable.SetActive(true);

        DisableInteractable();
    }

    public override bool CanUseInteractable()
    {
        return m_gameController.m_NPC.m_grabbedEnity == null;
    }
}
