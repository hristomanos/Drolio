using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    //[Header("Breakable game object")]
    //[SerializeField] GameObject m_BreakableObject;

    GameObject breakableObject;

    [Header("Explosion")]
    [SerializeField] float m_Force;
    [SerializeField] float m_Radius;
    [SerializeField] LayerMask m_LayerToHit;

    [Header("Face")]
    [SerializeField] GameObject m_Face;

    Rigidbody2D    m_RigidBody2D;
    BoxCollider2D  m_BoxCollider2D;
    SpriteRenderer m_SpriteRenderer;
    PlayerMovement m_PlayerMovement;
    TrailRenderer  m_TrailRenderer;
    Stomp          m_Stomp;

    

    private void Start()
    {
        m_RigidBody2D    = GetComponent<Rigidbody2D>();
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_BoxCollider2D  = GetComponent<BoxCollider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_TrailRenderer  = GetComponent<TrailRenderer>();
        m_Stomp          = GetComponent<Stomp>();
    }

    public void Die(Vector2 pointOfContact)
    {
        Freeze();
        SwapWithBreakableObject();
        Explode(pointOfContact,m_Force,m_Radius,m_LayerToHit);
    }

    void Freeze()
    {
        m_RigidBody2D.velocity = Vector3.zero;
        m_RigidBody2D.gravityScale = 0;

        m_PlayerMovement.enabled = false;
        m_BoxCollider2D.enabled  = false;
        m_SpriteRenderer.enabled = false;
        m_TrailRenderer.enabled  = false;
        m_Stomp.enabled          = false;
        m_Face.SetActive(false);
    }

    void SwapWithBreakableObject()
    {
        //m_BreakableObject.SetActive(true);

        breakableObject = ObjectPool.SharedInstance.GetPooledObject();
        if (breakableObject != null)
        {
            //breakableObject.transform.SetParent(transform);
            breakableObject.transform.position = transform.position;
            breakableObject.SetActive(true);
        }
    }

    public void Reset()
    {
        //m_BreakableObject.SetActive(false);
       // breakableObject.SetActive(false);
        m_RigidBody2D.velocity  = Vector3.zero;
        m_RigidBody2D.gravityScale = 2;

        breakableObject.transform.parent = null;
        m_PlayerMovement.enabled = true;
        m_BoxCollider2D.enabled  = true;
        m_SpriteRenderer.enabled = true;
        m_TrailRenderer.enabled  = true;
        m_Stomp.enabled          = true;
        m_Face.SetActive(true);
    }


    void Explode(Vector2 pointOfContact ,float force, float radius, LayerMask layerToHit)
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, layerToHit);

        foreach (var obj in objects)
        {
            Vector2 direction = (Vector2) obj.transform.position - pointOfContact;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }
}
