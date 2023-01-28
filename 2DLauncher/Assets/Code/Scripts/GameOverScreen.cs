using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScreen : MonoBehaviour
{
    [SerializeField] float m_transitionTime = 0.5f;
    [SerializeField] CanvasGroup m_canvasGroup;
    [SerializeField] GameObject m_RestartFromCheckPoint;

    private void Start()
    {
        m_canvasGroup.alpha = 0;
        m_canvasGroup.blocksRaycasts = false;
    }


    public void FadeIn()
    {
        StartCoroutine(LerpFunction(0,1,m_transitionTime));
    }

    public void FadeOut()
    {
        StartCoroutine(LerpFunction(1,0, m_transitionTime));
    }

    public void Reset()
    {
        m_canvasGroup.alpha = 0;
        m_canvasGroup.blocksRaycasts = false;
        m_RestartFromCheckPoint.SetActive(true);
    }

    IEnumerator LerpFunction(float startValue, float endValue, float duration)
    {
        float time = 0;
        m_canvasGroup.blocksRaycasts = true;

        yield return new WaitForSeconds(2.0f);


        while (time < duration)
        {
            m_canvasGroup.alpha = Mathf.Lerp(startValue, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        m_canvasGroup.alpha = 1;
        
    }

    public void DisableRestartFromCheckPointButton()
    {
        m_RestartFromCheckPoint.SetActive(false);
    }

    

}
