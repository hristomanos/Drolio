using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Basket : MonoBehaviour
{
    CinemachineImpulseSource m_ScreenShake;

    float m_TimeSpeed = 1; 

    private void Start()
    {
        m_ScreenShake = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_ScreenShake.GenerateImpulse();
            m_TimeSpeed = 0.5f;
            Handheld.Vibrate();
        }
    }

    private void Update()
    {
        Time.timeScale = m_TimeSpeed;
    }
}
