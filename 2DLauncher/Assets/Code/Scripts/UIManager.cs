using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI m_numberOfDiamondsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNumberOfDiamondsUI();
    }

    void UpdateNumberOfDiamondsUI()
    {
        m_numberOfDiamondsText.text = DiamondCounter.instance.GetNumberOfDiamonds().ToString();
    }

}
