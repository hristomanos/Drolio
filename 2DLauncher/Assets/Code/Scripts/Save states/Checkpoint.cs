using System.Collections;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] GameManager m_GameManager;

    [Header("Behaviour")]
    [SerializeField] Transform   m_ResetPosition;
    [SerializeField] float       m_LerpDuration = 1.0f;
    [SerializeField] bool        m_IsActivated = false;

    [Header("Visual")]
    [SerializeField] GameObject  m_PoleHinge;
    [SerializeField] GameObject  m_Flag;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") && CheckIfCurrentCheckPointIsNotSelf() )
        {
            m_GameManager.CurrentCheckpointID = gameObject.GetInstanceID();
            m_GameManager.SetPlayerResetPosition(m_ResetPosition);
            PlayAnimation();
        }
    }

    bool CheckIfCurrentCheckPointIsNotSelf()
    {
        if ( m_GameManager.CurrentCheckpointID != gameObject.GetInstanceID() )
        {
            return true;
        }
        else
            return false;
    }


    void PlayAnimation()
    {
        if ( !m_IsActivated )
        {
            StartCoroutine(Rotate180());
        }
    }

    IEnumerator Rotate180()
    {
        float timeElapsed = 0;

        Quaternion startRotation = m_PoleHinge.transform.rotation;
        Quaternion targetRotation = m_PoleHinge.transform.rotation * Quaternion.Euler(0, 0, -180);

        while ( timeElapsed < m_LerpDuration )
        {
            m_PoleHinge.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeElapsed / m_LerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        m_PoleHinge.transform.rotation = Quaternion.Euler(0, 0, 0);
        m_Flag.SetActive(true);
        m_IsActivated = true;
    }
}
