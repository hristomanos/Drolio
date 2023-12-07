using UnityEngine;

public class LivesManager : MonoBehaviour
{
    int m_NumberOfLives = 3;

    [SerializeField] int m_DefaultNumberOfLives = 3;

    public int GetNumberOfLives() { return m_NumberOfLives; }

    void Start()
    {
        m_NumberOfLives = m_DefaultNumberOfLives;
    }

    public void Add(int amount)
    {
        m_NumberOfLives += amount;
    }

    public void Decrease(int amount)
    {
        m_NumberOfLives -= amount;

        if ( m_NumberOfLives <= 0 )
        {
            m_NumberOfLives = 0;
        }
    }

    public string UpdateUI()
    {
        return m_NumberOfLives.ToString();
    }

    public void Reset()
    {
        m_NumberOfLives = 3;
    }
}
