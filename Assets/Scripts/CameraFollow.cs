using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject m_camera = null;

    public float m_cameraSpeed = 10.0f;

    private bool m_blending = true;
    public float m_blendTime = 3.0f;
    private float m_blendTimer = 0.0f;

    public Vector3 m_plannedLocal = Vector3.zero;
    private Quaternion m_plannedRot = Quaternion.identity;

    private Vector3 m_orginalPos = Vector3.zero;
    private Quaternion m_orginalRot = Quaternion.identity;

    private void Start()
    {
        m_orginalPos = m_camera.transform.localPosition;
        m_orginalRot = m_camera.transform.rotation;

        m_plannedRot = Quaternion.LookRotation(transform.TransformVector(-m_plannedLocal), Vector3.up);

        enabled = false;
    }

    private void Update()
    {
        if(m_blending)
        {
            m_blendTimer += Time.deltaTime;

            if(m_blendTimer >= m_blendTime)
            {
                m_blending = false;

                m_camera.transform.localPosition = m_plannedLocal;
                m_camera.transform.rotation = m_plannedRot;
            }
            else
            {
                float percent = m_blendTimer / m_blendTime;
                m_camera.transform.localPosition = Vector3.Lerp(m_orginalPos, m_plannedLocal, percent);
                m_camera.transform.rotation = Quaternion.Lerp(m_orginalRot, m_plannedRot, percent);
            }
        }
        else
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 changeInPos = Vector3.forward * input.y * m_cameraSpeed + Vector3.right * input.x * m_cameraSpeed;
            transform.Translate(changeInPos * Time.deltaTime, Space.Self);

            m_camera.transform.LookAt(transform.position);
        }
    }
}
