using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

//Game manager persists throught the game.
//Its role involves:
//1) reseting the player in case they fall
//2) Loading next level
//3) Keeping track of the player's stamina

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator m_Transition;
    [SerializeField] float m_TransitionTime;
   
    AudioManager m_AudioManager;


    private void Start()
    {
        m_AudioManager = AudioManager.instance;
        if (m_AudioManager == null)
        {
            Debug.LogError("No audiomanager found in the scene");
        }
    }

    public void LoadFollowingLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReturnToMainMenu()
    {
        StartCoroutine(LoadLevel(0));
        DiamondCounter.instance.ResetNumberofDiamonds();
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        m_Transition.SetTrigger("Start");

        yield return new WaitForSeconds(m_TransitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void PlayButton()
    {
        m_AudioManager.PlaySound("PlayButton");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
 
}
