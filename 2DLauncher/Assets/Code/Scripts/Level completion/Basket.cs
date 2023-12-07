using Cinemachine;
using UnityEngine;
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
        if ( collision.gameObject.CompareTag("Player") )
        {
            m_ScreenShake.GenerateImpulse();
            ApplySlowMotion();
            Handheld.Vibrate();
        }
    }

    void ApplySlowMotion()
    {
        m_TimeSpeed = 0.5f;
    }

    private void Update()
    {
        Time.timeScale = m_TimeSpeed;
    }
}
