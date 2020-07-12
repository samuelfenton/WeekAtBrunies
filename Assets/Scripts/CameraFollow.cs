using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject m_followObject = null;
    public Vector3 m_offset = Vector3.zero;

    private void Update()
    {
        Vector3 desiredPosition = m_followObject.transform.position + m_offset;

        transform.position = desiredPosition;

        transform.LookAt(m_followObject.transform.position);
    }
}
