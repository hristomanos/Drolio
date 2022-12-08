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

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (rigidbody.velocity.y > m_minPlayerVelocity)
            {
                m_Animator.Play("Jump", 0, 0.0f);
            }
        }
    }
}
