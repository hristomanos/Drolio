using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour
{
    [SerializeField] float m_Speed = 2f;

    Animator      m_Animator;
    RectTransform m_Target;
    SpriteRenderer spriteRenderer;

    bool touched;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Target = DiamondCounter.instance.m_DiamondImage;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!touched)
        {
            DiamondCounter.instance.AddADiamond();
            AudioManager.instance.PlaySound("Diamond");
            m_Animator.enabled = false;
            Animate();
            touched = true;
        }
    }

    void MoveToTargetPostion()
    {

        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(m_Target.position.x,
                                                                            m_Target.position.y,
                                                                            Camera.main.transform.position.z * -1));

        StartCoroutine(Move(transform.position, targetPosition));
    }

    IEnumerator Move(Vector2 initialPosition, Vector2 targetPosition)
    {
        float time = 0;

        while ( time < 1 )
        {
            time += m_Speed * Time.deltaTime;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, time);

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
        yield return null;
    }

    void Animate()
    {
        Vector2 endValue = new Vector2(transform.position.x,transform.position.y + 2);
        Sequence seq = transform.DOJump(endValue, 5, 1, 2).Join(spriteRenderer.DOFade(0,1)).SetLink(gameObject).OnComplete(() => Destroy(gameObject));
    }


}
