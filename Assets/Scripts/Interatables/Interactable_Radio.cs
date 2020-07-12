using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Radio : Interactable
{
    private AudioSource m_audioSource = null;

    public override void InitEntity(GameController p_gameController)
    {
        base.InitEntity(p_gameController);

        m_audioSource = GetComponent<AudioSource>();
    }

    public override void UseInteractable()
    {
        m_audioSource.mute = !m_audioSource.mute;
    }

    public override bool CanUseInteractable()
    {
        return m_gameController.m_NPC.m_grabbedEnity == null;
    }
}
