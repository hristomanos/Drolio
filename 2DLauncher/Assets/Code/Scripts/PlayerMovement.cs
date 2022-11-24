using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_RigidBody;

    [Range(0,5)]
    [SerializeField] int speed;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #if !UNITY_ANDROID && !UNITY_IPHONE
         MovePlayerVelocity(Input.GetAxisRaw("Horizontal"));
        #endif
    }

    public void MovePlayerVelocity(float horizontal)
    {
        m_RigidBody.velocity = new Vector3(horizontal * speed, m_RigidBody.velocity.y); // Move to the right
    }

}
