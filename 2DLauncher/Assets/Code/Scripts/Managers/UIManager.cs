using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] int m_totalNumberOfDiamondsInLevel;

    [SerializeField] TextMeshProUGUI m_numberOfDiamondsText;
    [SerializeField] TextMeshProUGUI m_remainingNumberOfDiamondsText;
    [SerializeField] TextMeshProUGUI m_numberOfLivesText;
    LivesManager m_LivesManager;

    [SerializeField] DiamondCounter diamondCounter;


    // Start is called before the first frame update
    void Start()
    {
        m_LivesManager = GetComponent<LivesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNumberOfDiamondsUI();
        UpdateRemainingNumberOfDiamondsUI();
        UpdateLivesUI();
    }

    void UpdateNumberOfDiamondsUI()
    {
        m_numberOfDiamondsText.text = DiamondCounter.instance.GetNumberOfDiamonds().ToString();
    }

    void UpdateRemainingNumberOfDiamondsUI()
    {
        m_remainingNumberOfDiamondsText.text = "/ " + m_totalNumberOfDiamondsInLevel.ToString();
    }

    void UpdateLivesUI()
    {
        if ( m_LivesManager != null )
        {
            m_numberOfLivesText.text = m_LivesManager.UpdateUI();
        }
        else
            Debug.LogError("Lives manager is empty");

    }

}
