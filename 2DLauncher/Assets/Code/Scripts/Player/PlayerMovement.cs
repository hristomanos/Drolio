using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D m_RigidBody;

    [Range(0,50)]
    [SerializeField] int m_Speed = 5;

    [SerializeField] float m_MaxVelocity = 20f;

    [SerializeField] float m_FallMultiplier = 2.5f;


    public float GetMaxVelocity() { return m_MaxVelocity; }
    public float GetVelocityY()   { return m_RigidBody.velocity.y; }

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
      //  ClampUpwardVelocity();
    }



    void Update()
    {
        #if UNITY_EDITOR
            MovePlayerVelocity(Input.GetAxisRaw("Horizontal"));
        #endif

    }

    public void MovePlayerVelocity(float horizontal)
    {
        if (this.enabled == true)
        {
            m_RigidBody.velocity = new Vector2(horizontal * m_Speed, m_RigidBody.velocity.y);
        }
    }


    #region Clamp velocity
        void ClampUpwardVelocity()
        {
            //if (m_RigidBody.velocity.y > 0)
            //{
            //    Vector2 temp = m_RigidBody.velocity;
            //    temp.y = Mathf.Clamp(temp.y, 0, m_MaxVelocity);
            //}

            m_RigidBody.velocity += Vector2.up * Physics2D.gravity.y * (m_FallMultiplier - 1) * Time.deltaTime;

        }

        void ClampVelocity()
        {
            m_RigidBody.velocity = Vector2.ClampMagnitude(m_RigidBody.velocity, m_MaxVelocity);
        }
    #endregion




}
