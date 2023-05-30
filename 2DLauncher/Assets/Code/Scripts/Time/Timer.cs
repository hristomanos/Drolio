using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI m_TextUI;
    float m_Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_TextUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer = Time.time;
        m_TextUI.text = "Timer: " + m_Timer.ToString("F1");
    }
}
