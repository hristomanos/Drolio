using UnityEngine;


public class Stomp : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] float m_Force;

    [Header("Dependencies")]
    [SerializeField] StaminaController m_StaminaController;

    [Header("Particle effect")]
    [SerializeField] ParticleSystem m_Dust;

    Rigidbody2D m_RigidBody;
    Animator    m_Animator;

    private bool g_ButtonPressed = false;
    public bool ButtonPressed { get => g_ButtonPressed; set => g_ButtonPressed = value; }

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessPCInput();
    }

    void ProcessPCInput()
    {
        if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) )
        {
            ResetUpwardVelocity();
            ApplyDownwardImpulseForce();
            ButtonPressed = true;
        }
    }

    public void TouchButton()
    {
        ResetUpwardVelocity();
        ApplyDownwardImpulseForce();
        ButtonPressed = true;
    }

    void ResetUpwardVelocity()
    {
        if ( m_RigidBody.velocity.y > 0 )
        {
            m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, 0.0f);
        }
    }

    void ApplyDownwardImpulseForce()
    {
        m_RigidBody.AddForce(Vector3.down * m_Force, ForceMode2D.Impulse);
    }

    void CreateDust()
    {
        m_Dust.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( Mathf.Abs(m_RigidBody.velocity.y) > 5 && collision.gameObject.layer == 6 )
        {
            CreateDust();
            m_Animator.Play("Squeeze", 0, 0);
            AudioManager.instance.PlaySound("Stomp");
        }
    }

}
