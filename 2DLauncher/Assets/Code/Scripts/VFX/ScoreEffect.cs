using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreEffect : MonoBehaviour
{

    RectTransform scorePlusOne;
    TextMeshProUGUI scorePlusOneText;

    // Start is called before the first frame update
    void Awake()
    {
        scorePlusOne = GetComponent<RectTransform>();
        scorePlusOneText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        scorePlusOneText.DOFade(0, 1.5f);
        scorePlusOne.DOMoveY(transform.position.y + 8, 1.5f).OnComplete(() => Destroy(gameObject));
    }


}
