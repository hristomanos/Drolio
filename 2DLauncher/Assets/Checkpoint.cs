using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Transform   m_ResetPosition;

    [SerializeField] float lerpDuration = 1.0f;

    [SerializeField] GameObject m_PoleHinge;
    [SerializeField] GameObject m_Flag;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && m_GameManager.CurrentCheckpointID != gameObject.GetInstanceID())
        {
            m_GameManager.CurrentCheckpointID = gameObject.GetInstanceID();
            m_GameManager.SetPlayerResetPosition(m_ResetPosition);
            StartCoroutine(Rotate180());
        }
    }

    

    IEnumerator Rotate180()
    {
        float timeElapsed = 0;
        
        Quaternion startRotation = m_PoleHinge.transform.rotation;
        Quaternion targetRotation = m_PoleHinge.transform.rotation * Quaternion.Euler(0, 0, -180);

        while (timeElapsed < lerpDuration)
        {
            m_PoleHinge.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        m_PoleHinge.transform.rotation = Quaternion.Euler(0, 0, 0);
        m_Flag.SetActive(true);
        
    }
}
