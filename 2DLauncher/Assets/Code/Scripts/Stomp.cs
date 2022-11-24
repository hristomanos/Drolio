using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
                     Rigidbody m_RigidBody;
    [SerializeField] int force;

    [SerializeField]  StaminaController m_StaminaController;

    [SerializeField] float m_CoolDownTimer;
    [SerializeField] float m_CoolDownMaxTime = 2;
    [SerializeField] float m_MaxVelocity;

    bool m_canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        m_CoolDownTimer = m_CoolDownMaxTime;
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxisRaw("Vertical");
       // m_canJump
        if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_StaminaController.Stomp())
            {
                m_RigidBody.AddForce(Vector3.down * force, ForceMode.Impulse);
            }
            m_canJump = false;
        }

        // if (!m_canJump)
        // CoolDown();
        Debug.Log("Velocity: " + m_RigidBody.velocity);
    }

    public void TouchButton()
    {
        if (m_StaminaController.Stomp())
        {
            if (m_RigidBody.velocity.y > 0)
            {
                m_RigidBody.velocity = Vector3.zero;
            }
            m_RigidBody.AddForce(Vector3.down * force, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        m_RigidBody.velocity = Vector3.ClampMagnitude(m_RigidBody.velocity, m_MaxVelocity);
    }

    void CoolDown()
    {
        m_CoolDownTimer -= Time.deltaTime;

        if (m_CoolDownTimer <= 0)
        {
            m_canJump = true;
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
