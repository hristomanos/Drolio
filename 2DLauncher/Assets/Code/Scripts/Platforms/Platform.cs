using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Animator m_Animator;

    [Header("Activate")]
    [SerializeField] float m_minPlayerVelocity = 6;

    void Start()
    {
        m_Animator = GetComponent<Animator>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
           // rigidbody.AddForce(Vector2.up * (rigidbody.velocity.y + 5.0f), ForceMode2D.Impulse);

            if (rigidbody.velocity.y > m_minPlayerVelocity)
            {
                m_Animator.Play("Jump", 0, 0.0f);
            }
        }
    }
}
