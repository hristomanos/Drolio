using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    int m_NumberOfLives = 3;

    [SerializeField] int m_DefaultNumberOfLives = 3;

    public int GetNumberOfLives() { return m_NumberOfLives; }
    
    

    // Start is called before the first frame update
    void Start()
    {
        m_NumberOfLives = m_DefaultNumberOfLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds amount to lives.
    /// </summary>
    /// <param name="amount"></param>
    public void Add(int amount)
    {
        m_NumberOfLives += amount;
    }

    /// <summary>
    /// Removes amount of lives.
    /// </summary>
    /// <param name="amount"></param>
    public void Decrease(int amount)
    {
        m_NumberOfLives -= amount;

        if (m_NumberOfLives <= 0)
        {
            m_NumberOfLives = 0;
            //Game over!    
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
