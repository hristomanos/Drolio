using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    Rigidbody m_RigidBody;

    [SerializeField] int m_Force;

    [SerializeField]  StaminaController m_StaminaController;

    [SerializeField] float m_CoolDownTimer;
    [SerializeField] float m_CoolDownMaxTime = 2;


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

        if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_StaminaController.Stomp())
            {
                m_RigidBody.AddForce(Vector3.down * m_Force, ForceMode.Impulse);
            }
            
        }

        
    }

    public void TouchButton()
    {
        if (m_StaminaController.Stomp())
        {
            if (m_RigidBody.velocity.y > 0)
            {
                m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0.0f, m_RigidBody.velocity.z);
            }
            m_RigidBody.AddForce(Vector3.down * m_Force, ForceMode.Impulse);
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
