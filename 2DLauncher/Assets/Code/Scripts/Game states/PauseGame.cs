using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    [SerializeField] GameObject m_PausePanel;
    bool m_GameIsPaused = false;
    GameManager m_GameManager;

    void Start()
    {
        m_GameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    m_GameIsPaused = !m_GameIsPaused;
        //    Pause();
        //}
    }
    public void RestartButton()
    {
        m_PausePanel.SetActive(false);
        Time.timeScale = 1;
        m_GameManager.RestartLevel();
    }

    void Pause()
    {
        if (m_GameIsPaused)
        {
            m_PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            m_PausePanel.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
