using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomer : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_vCam;
    [SerializeField] PlayerMovement m_PlayerMovement;
    
    Camera m_mainCamera;
    CinemachineBrain m_cinemachineBrain;

    [SerializeField] GameObject player;


    float m_playerMaxVelocity;

    float m_currentMaxVelocity = 0;

    void Start()
    {
        m_mainCamera = Camera.main;
        m_cinemachineBrain = (m_mainCamera = null) ? null : GetComponent<CinemachineBrain>();
        //m_vCam = (m_cinemachineBrain = null) ? null : m_cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;
        m_playerMaxVelocity = m_PlayerMovement.GetMaxVelocity();
    }

    private void FixedUpdate()
    {
        SetOrthographicSize();
    }

    void SetOrthographicSize()
    {
        if (m_vCam != null && m_PlayerMovement != null)
        {
            float currentSpeed = Mathf.Abs(m_PlayerMovement.GetVelocityY());
           
            CalculateCurrentMaxVelocity(currentSpeed);

            //Inverse Lerp returns a value between 0 - 1. It is the same as getting the percentage between two values.
            //float speedPercentage = Mathf.InverseLerp(0f, m_playerMaxVelocity, currentSpeed);

            float speedPercentage = Mathf.InverseLerp(0f, m_playerMaxVelocity, m_currentMaxVelocity);

          

            //Making transition between 0 and 1 smoother.
            //speedPercentage = Mathf.SmoothStep(0, 1, speedPercentage);
            speedPercentage = Mathf.SmoothStep(0, 1, speedPercentage);


            
            //Update camera zoom.
            m_vCam.m_Lens.OrthographicSize = Mathf.Lerp(12.32f, m_currentMaxVelocity + 5, speedPercentage);
            ZoomIn();
        }
    }

    IEnumerator ZoomIn()
    {
        yield return new WaitForSeconds(5.0f);

        m_currentMaxVelocity -= Time.deltaTime;
        if (m_currentMaxVelocity <= 0)
        {
            m_currentMaxVelocity = 0;
        }
    }


    void CalculateCurrentMaxVelocity(float playerSpeed)
    {
        if (m_currentMaxVelocity < playerSpeed)
        {
            m_currentMaxVelocity = playerSpeed;
        }

        if (m_currentMaxVelocity > 20.0f)
        {
            m_currentMaxVelocity = 20.0f;
        }

        Debug.Log(m_currentMaxVelocity);
    }

    void GroundCheck()
    {
        Ray ray;
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down);


    }


}
