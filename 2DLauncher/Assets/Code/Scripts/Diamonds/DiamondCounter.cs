using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DiamondCounter : MonoBehaviour
{

    public static DiamondCounter instance;

    [SerializeField] GameObject scoreEffect;
    [SerializeField] GameObject WorldCanvas;

    private int m_NumberOfDiamonds;

    public int GetNumberOfDiamonds() { return m_NumberOfDiamonds; }

    public void ResetNumberofDiamonds() { m_NumberOfDiamonds = 0; }


    public RectTransform m_DiamondImage;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        m_NumberOfDiamonds = 0;
    }

    public void AddADiamond()
    {
        ++m_NumberOfDiamonds;
    }

    public void DoFloatingText(Vector3 position)
    {
        GameObject floatingText = Instantiate(scoreEffect, position, Quaternion.identity );
        floatingText.transform.SetParent(WorldCanvas.transform);
    }

}
