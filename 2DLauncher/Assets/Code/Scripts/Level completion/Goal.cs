using System.Collections;
using UnityEngine;

//This script checks if the player has managed to hit the end of the level thus completing it.
public class Goal : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] GameObject m_Player;
    [SerializeField] GameManager m_GameManager;

    [Header("Particles")]
    [SerializeField] ParticleSystem m_Fireworks;

    [Header("Visual FX")]
    [SerializeField] Animator m_HollowSquareAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Player") )
        {

            AudioManager.instance.PlaySound("LevelComplete");

            FreezePlayer();

            m_HollowSquareAnimator.SetTrigger("LevelComplete");

            m_GameManager.LoadFollowingLevel();
        }
    }

    void FreezePlayer()
    {
        m_Player.GetComponent<PlayerMovement>().enabled = false;
        m_Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        m_Player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }



    void PlayFireworksAnimation()
    {
        StartCoroutine(FireFireworks());
    }

    IEnumerator FireFireworks()
    {

        yield return new WaitForSeconds(1.5f);

        AudioManager.instance.PlaySound("Fireworks");

        m_Fireworks.Play();


        yield return new WaitForSeconds(3.0f);

        m_GameManager.LoadFollowingLevel();
    }





}
