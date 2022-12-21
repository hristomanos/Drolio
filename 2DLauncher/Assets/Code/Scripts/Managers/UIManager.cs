using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] int m_totalNumberOfDiamondsInLevel;

    [SerializeField] TextMeshProUGUI m_numberOfDiamondsText;
    [SerializeField] TextMeshProUGUI m_remainingNumberOfDiamondsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNumberOfDiamondsUI();
        UpdateRemainingNumberOfDiamondsUI();
    }

    void UpdateNumberOfDiamondsUI()
    {
        m_numberOfDiamondsText.text = DiamondCounter.instance.GetNumberOfDiamonds().ToString();
    }

    void UpdateRemainingNumberOfDiamondsUI()
    {
        m_remainingNumberOfDiamondsText.text = "/ " + m_totalNumberOfDiamondsInLevel.ToString();
    }

}
