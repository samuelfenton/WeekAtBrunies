using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject m_inGameUI = null;
    public GameObject m_pauseMenuUI = null;

    private Entity_NPC m_NPC = null;
    private AudioSource m_musicSource = null;
    public void InitUI()
    {
        m_NPC = FindObjectOfType<Entity_NPC>();

        m_inGameUI.SetActive(true);
        m_pauseMenuUI.SetActive(false);

        m_musicSource = FindObjectOfType<Interactable_Radio>().GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_inGameUI.activeSelf)
            {
                m_inGameUI.SetActive(false);
                m_pauseMenuUI.SetActive(true);
            }
            else
            {
                m_inGameUI.SetActive(true);
                m_pauseMenuUI.SetActive(false);
            }
        }
    }

    public void Btn_Command_PickUp()
    {
        m_NPC.NewCommand(Entity_NPC.POSSIBLE_COMMANDS.PICK_UP);
    }

    public void Btn_Command_Drop()
    {
        m_NPC.NewCommand(Entity_NPC.POSSIBLE_COMMANDS.DROP);
    }

    public void Btn_Resume()
    {
        m_inGameUI.SetActive(true);
        m_pauseMenuUI.SetActive(false);
    }

    private bool m_isMuted = false;
    public void Btn_Mute()
    {
        if (m_musicSource != null)
        { 
            m_isMuted = !m_isMuted;

            m_musicSource.volume = m_isMuted ? 0.0f : 0.3f;
        }
    }

    public void Btn_Quit()
    {
        Application.Quit();
    }
}
