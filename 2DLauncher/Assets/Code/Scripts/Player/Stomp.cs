using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    Rigidbody2D m_RigidBody;

    [SerializeField] int m_Force;

    [SerializeField]  StaminaController m_StaminaController;

    [SerializeField] float m_CoolDownTimer;
    [SerializeField] float m_CoolDownMaxTime = 2;

    [SerializeField] float m_FallMultiplier = 2.5f;
    [SerializeField] float m_LowStompMultiplier = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_CoolDownTimer = m_CoolDownMaxTime;
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxisRaw("Vertical");

            if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (m_StaminaController.Stomp())
                {
                    if (m_RigidBody.velocity.y > 0)
                    {
                        m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, 0.0f);
                    }


                   //m_RigidBody.velocity += Vector2.up * Physics2D.gravity.y * (m_FallMultiplier - 1) * Time.deltaTime;
                     m_RigidBody.AddForce(Vector3.down * m_Force, ForceMode2D.Impulse);
                }
            
            }


        


    }

    public void TouchButton()
    {
        if (m_StaminaController.Stomp())
        {
            if (m_RigidBody.velocity.y > 0)
            {
                m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, 0.0f);
            }

            m_RigidBody.AddForce(Vector3.down * m_Force, ForceMode2D.Impulse);
        }
    }

   

    void CoolDown()
    {
        m_CoolDownTimer -= Time.deltaTime;

        if (m_CoolDownTimer <= 0)
        {
            m_CoolDownTimer = m_CoolDownMaxTime;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (Mathf.Abs(m_RigidBody.velocity.y) > 5 && collision.gameObject.layer == 6)
        {
            AudioManager.instance.PlaySound("Stomp");
        }
    }

}
