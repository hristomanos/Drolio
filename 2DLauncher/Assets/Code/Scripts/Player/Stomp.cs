using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stomp : MonoBehaviour
{
    [Header("Downward Force")]
    [SerializeField] float m_Force;

    [SerializeField] StaminaController m_StaminaController;
    [SerializeField] ParticleSystem m_Dust;

    Rigidbody2D m_RigidBody;
    Animator m_Animator;

    public bool buttonPressed = false;

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        float y = Input.GetAxisRaw("Vertical");
       
        if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_RigidBody.velocity.y > 0)
            {
                m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, 0.0f);
            }

            buttonPressed = true;

            m_RigidBody.AddForce(Vector3.down * m_Force, ForceMode2D.Impulse);
        }
    }

    void ProcessPCInput()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_RigidBody.velocity.y > 0)
            {
                m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, 0.0f);
            }

            buttonPressed = true;

            m_RigidBody.AddForce(Vector3.down * m_Force, ForceMode2D.Impulse);
        }
    }

    public void TouchButton()
    {
        if (m_RigidBody.velocity.y > 0)
        {
            m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, 0.0f);
        }

        buttonPressed = true;
        m_RigidBody.AddForce(Vector3.down * m_Force, ForceMode2D.Impulse);
    }

    void CreateDust()
    {
        m_Dust.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(m_RigidBody.velocity.y) > 5 && collision.gameObject.layer == 6)
        {
            CreateDust();
            m_Animator.Play("Squeeze", 0,0);
            AudioManager.instance.PlaySound("Stomp");
        }
    }

}
