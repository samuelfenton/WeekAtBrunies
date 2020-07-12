using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class IntroScene : MonoBehaviour
{
    [Header("DEBUG")]
    public bool m_skip = false;

    public TextMeshProUGUI m_introText = null;

    public struct TextStruct
    {
        public TextStruct(string p_text, float p_time)
        {
            m_text = p_text;
            m_time = p_time;
        }

        public string m_text;
        public float m_time;
    };

    public List<TextStruct> m_introSequence = new List<TextStruct>();

    public CameraFollow m_cameraFollowScript = null;
    private GameController m_gameController = null;
    private int m_textIndex = 0;
    private float m_timer = 0.0f;

    private void Start()
    {
        m_gameController = FindObjectOfType<GameController>();

        m_introSequence.Add(new TextStruct("This is you, Brunie", 2.0f));
        m_introSequence.Add(new TextStruct("You died after working on a game jam too long...", 3.0f));
        m_introSequence.Add(new TextStruct("Luckily your friend is here to look after you!", 3.0f));
        m_introSequence.Add(new TextStruct("Alllll week", 2.0f));
        m_introSequence.Add(new TextStruct("Made by Sam&Jack <3", 0.1f));

        m_timer = m_introSequence[m_textIndex].m_time;
        m_introText.text = m_introSequence[m_textIndex].m_text;
    }

    private void Update()
    {
        m_timer -= Time.deltaTime;

        if(m_timer <0.0f || m_skip)
        {
            m_textIndex++;

            if(m_textIndex >= m_introSequence.Count || m_skip)
            {
                m_gameController.enabled = true;
                m_cameraFollowScript.enabled = true;

                Destroy(gameObject);
            }
            else
            {
                m_timer = m_introSequence[m_textIndex].m_time;
                m_introText.text = m_introSequence[m_textIndex].m_text;
            }
        }
    }
}
