using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D m_RigidBody;


    [Header("Behaviour")]
    [Range(0, 50)] [SerializeField] int   m_Speed = 5;

    [SerializeField] float m_MaxVelocity = 20f;



    public float GetMaxVelocity() { return m_MaxVelocity; }
    public float GetVelocityY()   { return m_RigidBody.velocity.y; }

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        #if UNITY_EDITOR
            MovePlayerVelocity(Input.GetAxisRaw("Horizontal"));
        #endif

        SetMaxVelocity();

    }

    public void MovePlayerVelocity(float horizontal)
    {
        if (this.enabled == true)
        {
            m_RigidBody.velocity = new Vector2(horizontal * m_Speed, m_RigidBody.velocity.y);
        }
    }

    void SetMaxVelocity()
    {
        if (m_RigidBody.velocity.magnitude >= m_MaxVelocity)
        {
            m_RigidBody.velocity = Vector2.ClampMagnitude(m_RigidBody.velocity, m_MaxVelocity);
        }
    }

}
