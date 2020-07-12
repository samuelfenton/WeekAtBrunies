using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Brunie : Entity
{
    [Header("Grabbed Varibles")]
    public float m_grabbedForce = 10.0f;
    public float m_grabDistance = 2.0f;

    public GameObject m_torsoJoint = null;

    private Rigidbody m_torsoRB = null;

    public override void InitEntity(GameController p_gameController)
    {
        base.InitEntity(p_gameController);

        if (m_torsoJoint != null)
            m_torsoRB = m_torsoJoint.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Update the entity, same time as update. Should be called by gamecontroller
    /// </summary>
    public override void UpdateEntity()
    {
        base.UpdateEntity();
    }

    /// <summary>
    /// Brunie has been grabbed force body to move towards position
    /// </summary>
    /// <param name="p_position"></param>
    public void BeenGrabbed(Vector3 p_position)
    {
        Vector3 torsoToGrab = p_position - m_torsoJoint.transform.position;
        m_torsoRB.AddForce(torsoToGrab * m_grabbedForce, ForceMode.Acceleration);
    }
}
