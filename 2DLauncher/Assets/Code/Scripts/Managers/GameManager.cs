using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Game manager persists throught the game.
//Its role involves:
//1) reseting the player in case they fall
//2) Loading next level
//3) Keeping track of the player's stamina

public class GameManager : MonoBehaviour
{

    [SerializeField] Animator m_Transition;
    [SerializeField] float m_TransitionTime;
    [SerializeField] GameObject m_Player;

    [SerializeField] Transform m_PlayerResetPosition;
    [SerializeField] Transform m_BorderLine;

    [SerializeField] DiamondCounter diamondCounter;

    AudioManager m_AudioManager;

    GameOverScreen m_gameOverScreen;

    bool m_hasPlayedDeathSound = false;

    LivesManager m_LivesManager;


    public void SetPlayerResetPosition(Transform resetPosition) { m_PlayerResetPosition = resetPosition; }
    public int CurrentCheckpointID { get; set; }

    private void Awake()
    {
        m_LivesManager = GetComponent<LivesManager>();
        m_gameOverScreen = GetComponent<GameOverScreen>();
        Time.timeScale = 1;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;

        m_AudioManager = AudioManager.instance;
        if ( m_AudioManager == null )
        {
            Debug.LogError("No audiomanager found in the scene");
        }
    }

    void Update()
    {
        if ( m_BorderLine != null && m_PlayerResetPosition != null )
        {
            if ( PlayerHasFallenOff() )
            {
                if ( !m_hasPlayedDeathSound )
                {
                    AudioManager.instance.PlaySound("PlayersFallen");
                    m_Player.SetActive(false);
                    m_gameOverScreen.FadeIn();
                    m_hasPlayedDeathSound = true;
                }

            }
        }
    }

    public void LoadFollowingLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReturnToMainMenu()
    {
        StartCoroutine(LoadLevel(0));
        diamondCounter.Reset();
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        m_Transition.SetTrigger("Start");

        yield return new WaitForSeconds(m_TransitionTime);

        //SceneManager.LoadScene(levelIndex);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);

        // Wait until the asynchronous scene fully loads
        while ( !asyncLoad.isDone )
        {
            yield return null;
        }

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

    public void RestartFromCheckpoint()
    {
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        m_Transition.SetTrigger("Start");

        yield return new WaitForSeconds(m_TransitionTime);

        Reset();
        m_Transition.SetTrigger("End");
    }


    public void Reset()
    {
        //AudioManager.instance.PlaySound("PlayersFallen");

        m_Player.SetActive(true);
        m_hasPlayedDeathSound = false;
        m_Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        m_Player.transform.position = new Vector3(m_PlayerResetPosition.position.x, m_PlayerResetPosition.position.y);
        m_Player.GetComponent<StaminaController>().Reset();
        m_Player.GetComponent<Death>().Reset();
        m_gameOverScreen.Reset();
    }


    public void KillPlayer(Vector2 pointOfContact)
    {
        AudioManager.instance.PlaySound("PlayersFallen");
        m_LivesManager.Decrease(1);

        if ( PlayerIsOutOfLives() )
        {
            m_gameOverScreen.DisableRestartFromCheckPointButton();
        }

        m_Player.GetComponent<Death>().Die(pointOfContact);
        m_gameOverScreen.FadeIn();
        //StartCoroutine(Delay(2.0f));
    }

    bool PlayerIsOutOfLives()
    {
        if ( m_LivesManager.GetNumberOfLives() <= 0 )
        {
            return true;
        }
        else
            return false;

    }

    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        m_Player.transform.position = new Vector3(m_PlayerResetPosition.position.x, m_PlayerResetPosition.position.y);
        m_Player.GetComponent<Death>().Reset();
        m_Player.GetComponent<StaminaController>().Reset();
    }

    private bool PlayerHasFallenOff()
    {
        if ( m_Player.transform.position.y < m_BorderLine.position.y )
        {
            return true;
        }
        else
            return false;
    }

}
