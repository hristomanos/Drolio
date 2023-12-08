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

    [SerializeField] GameObject scoreEffect;
    [SerializeField] GameObject WorldCanvas;


    // Start is called before the first frame update
    void Start()
    {
        m_LivesManager = GetComponent<LivesManager>();
        diamondCounter.Changed += UpdateNumberOfDiamondsUI;
        UpdateNumberOfDiamondsUI(new Vector3(-100, -100));
    }

    private void OnDestroy()
    {
        diamondCounter.Changed -= UpdateNumberOfDiamondsUI;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRemainingNumberOfDiamondsUI();
        UpdateLivesUI();
    }

    void UpdateNumberOfDiamondsUI(Vector3 position)
    {
        m_numberOfDiamondsText.text = diamondCounter.Count.ToString();
        DoFloatingText(position);
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

    public void DoFloatingText(Vector3 position)
    {
        GameObject floatingText = Instantiate(scoreEffect, position, Quaternion.identity );
        floatingText.transform.SetParent(WorldCanvas.transform);
    }

}
