using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script checks if the player has managed to hit the end of the level thus completing it.
public class Goal : MonoBehaviour
{
    [SerializeField] GameObject m_Player;

    [SerializeField] GameManager m_GameManager;

    [SerializeField] ParticleSystem m_Fireworks;

    [SerializeField] Animator m_HollowSquareAnimator;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //Play cheerful sound
            AudioManager.instance.PlaySound("LevelComplete");

            //Freeze player
            m_Player.GetComponent<PlayerMovement>().enabled = false;
            m_Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            m_Player.GetComponent<Rigidbody>().useGravity = false;

            //Play animation
            m_HollowSquareAnimator.SetTrigger("LevelComplete");

            //StartCoroutine(FireFireworks());

            m_GameManager.LoadFollowingLevel();
        }
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
