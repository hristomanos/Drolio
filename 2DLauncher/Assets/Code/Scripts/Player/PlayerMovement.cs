using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D m_RigidBody;

    [Range(0,50)]
    [SerializeField] int speed = 5;


    [SerializeField] float m_MaxVelocity = 30f;

    

    public float GetMaxVelocity() { return m_MaxVelocity; }
    public float GetVelocityY() { return m_RigidBody.velocity.y; }

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
                MovePlayerVelocity(Input.GetAxisRaw("Horizontal"));
        #endif
    }

    private void FixedUpdate()
    {
        m_RigidBody.velocity = Vector2.ClampMagnitude(m_RigidBody.velocity, m_MaxVelocity);
    }

    public void MovePlayerVelocity(float horizontal)
    {
        
        m_RigidBody.velocity = new Vector2(horizontal * speed, m_RigidBody.velocity.y); // Move to the right
    }

}
