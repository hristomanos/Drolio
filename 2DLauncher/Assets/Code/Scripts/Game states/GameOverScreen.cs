using System.Collections;
using UnityEngine;


public class GameOverScreen : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] float m_TransitionTime = 0.5f;

    [Header("Dependencies")]
    [SerializeField] CanvasGroup m_CanvasGroup;
    [SerializeField] GameObject  m_RestartFromCheckPoint;

    private void Start()
    {
        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.blocksRaycasts = false;
    }


    public void FadeIn()
    {
        StartCoroutine(LerpFunction(0, 1, m_TransitionTime));
    }

    public void FadeOut()
    {
        StartCoroutine(LerpFunction(1, 0, m_TransitionTime));
    }

    public void Reset()
    {
        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.blocksRaycasts = false;
        m_RestartFromCheckPoint.SetActive(true);
    }

    IEnumerator LerpFunction(float startValue, float endValue, float duration)
    {
        float time = 0;
        m_CanvasGroup.blocksRaycasts = true;

        yield return new WaitForSeconds(2.0f);


        while ( time < duration )
        {
            m_CanvasGroup.alpha = Mathf.Lerp(startValue, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        m_CanvasGroup.alpha = 1;

    }

    public void DisableRestartFromCheckPointButton()
    {
        m_RestartFromCheckPoint.SetActive(false);
    }



}
