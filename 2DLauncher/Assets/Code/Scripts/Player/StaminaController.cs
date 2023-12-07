using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for handling and updating the stamina bar.
/// </summary>
public class StaminaController : MonoBehaviour
{
    [Header("Stamina main parameters")]
    [SerializeField] float m_CurrentPlayerStamina = 100.0f; //Actual player stamina
    [SerializeField] float m_MaxPlayerStamina = 100.0f;
    [SerializeField] float m_StompCost = 25f;
    [SerializeField] float m_staminaRegenSpeed;


    [Header("Stamina UI parameters")]
    [SerializeField] Image m_StaminaSlider_Bar;

    WaitForSeconds m_RegenTick = new WaitForSeconds(0.01f);
    Coroutine m_Regen;

    public bool Stomp()
    {
        //Stomp cannot be used if there is not enough stamina
        if ( m_CurrentPlayerStamina - m_StompCost >= 0 )
        {
            m_CurrentPlayerStamina -= m_StompCost;
            UpdateUI();

            if ( m_Regen != null )
            {
                StopCoroutine(m_Regen);
            }

            m_Regen = StartCoroutine(RegenStamina());

            return true;
        }
        else
        {
            return false;
        }
    }

    void Regenerate()
    {

        if ( m_CurrentPlayerStamina <= m_MaxPlayerStamina )
        {
            m_CurrentPlayerStamina += m_staminaRegenSpeed * Time.deltaTime;
            UpdateUI();
        }
    }

    IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while ( m_CurrentPlayerStamina < m_MaxPlayerStamina )
        {
            m_CurrentPlayerStamina += m_MaxPlayerStamina / 100 * m_staminaRegenSpeed;

            UpdateUI();
            yield return m_RegenTick;
        }

        m_Regen = null;
    }


    public void UpdateUI()
    {
        m_StaminaSlider_Bar.fillAmount = m_CurrentPlayerStamina / m_MaxPlayerStamina;
    }

    public void Reset()
    {
        m_CurrentPlayerStamina = m_MaxPlayerStamina;
        m_StaminaSlider_Bar.fillAmount = m_MaxPlayerStamina / m_MaxPlayerStamina;
    }

}
