using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private Entity_NPC m_NPC = null;

    public void InitUI()
    {
        m_NPC = FindObjectOfType<Entity_NPC>();
    }

    public void Btn_Command_PickUp()
    {
        m_NPC.NewCommand(Entity_NPC.POSSIBLE_COMMANDS.PICK_UP);
    }

    public void Btn_Command_Drop()
    {
        m_NPC.NewCommand(Entity_NPC.POSSIBLE_COMMANDS.DROP);
    }
}
