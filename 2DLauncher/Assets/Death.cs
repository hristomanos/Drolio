using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [Header("Breakable game object")]
    [SerializeField] GameObject m_BreakableObject;

    [Header("Explosion")]
    [SerializeField] float m_force;
    [SerializeField] float m_radius;
    [SerializeField] LayerMask m_LayerToHit;


    Rigidbody2D    m_rigidBody2D;
    BoxCollider2D  m_boxCollider2D;
    SpriteRenderer m_spriteRenderer;
    PlayerMovement m_playerMovement;
    TrailRenderer  m_trailRenderer;
    Stomp          m_stomp;

    private void Start()
    {
        m_rigidBody2D    = GetComponent<Rigidbody2D>();
        m_playerMovement = GetComponent<PlayerMovement>();
        m_boxCollider2D  = GetComponent<BoxCollider2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_trailRenderer  = GetComponent<TrailRenderer>();
        m_stomp          = GetComponent<Stomp>();
    }

    public void Die(Vector2 pointOfContact)
    {
        Freeze();
        SwapWithBreakableObject();
        Explode(pointOfContact,m_force,m_radius,m_LayerToHit);
    }

    void Freeze()
    {
        m_rigidBody2D.velocity = Vector3.zero;
        m_rigidBody2D.gravityScale = 0;

        m_playerMovement.enabled = false;
        m_boxCollider2D.enabled  = false;
        m_spriteRenderer.enabled = false;
        m_trailRenderer.enabled  = false;
        m_stomp.enabled          = false;
    }

    void SwapWithBreakableObject()
    {
        m_BreakableObject.SetActive(true);
    }

    public void Reset()
    {
        m_BreakableObject.SetActive(false);

        m_rigidBody2D.velocity  = Vector3.zero;
        m_rigidBody2D.gravityScale = 1;

        m_playerMovement.enabled = true;
        m_boxCollider2D.enabled  = true;
        m_spriteRenderer.enabled = true;
       // m_trailRenderer.enabled  = true;
        m_stomp.enabled          = true;
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
