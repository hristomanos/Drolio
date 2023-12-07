using UnityEngine;

public class Spikes : MonoBehaviour
{

    [SerializeField] protected GameManager m_gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.CompareTag("Player") )
        {
            //m_gameManager.Reset();
            //collider.
            m_gameManager.KillPlayer(collision.GetContact(0).point);
        }
    }


}
