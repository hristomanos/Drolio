using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script checks if the player has managed to hit the end of the level thus completing it.
public class Goal : MonoBehaviour
{
    [SerializeField] GameObject m_Player;
    [SerializeField] StaminaController m_StaminaController;

    [SerializeField] Transform m_ResetPosition;
    [SerializeField] Transform m_BorderLine;

    [SerializeField] GameManager m_GameManager;


   
    void Update()
    {
        CheckIfPlayerHasFallenOff();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Play complete level sound
        AudioManager.instance.PlaySound("LevelComplete");

        //Zero velocity
        m_Player.GetComponent<PlayerMovement>().enabled = false;
        m_Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        m_Player.GetComponent<Rigidbody>().useGravity = false;
        //Call Game manager for next level
        m_GameManager.LoadFollowingLevel();
    }

    private void Reset()
    {
        AudioManager.instance.PlaySound("PlayersFallen");

        m_Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        m_Player.transform.position = new Vector3(m_ResetPosition.position.x, m_ResetPosition.position.y);
        m_StaminaController.Reset();

    }

    private void CheckIfPlayerHasFallenOff()
    {
        if (m_Player.transform.position.y < m_BorderLine.position.y)
        {
            Reset();
        }
    }

}
