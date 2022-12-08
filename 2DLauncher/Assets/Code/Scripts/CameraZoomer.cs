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

    float m_playerMaxVelocity;

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

            //Inverse Lerp returns a value between 0 - 1. It is the same as getting the percentage between two values.
            float speedPercentage = Mathf.InverseLerp(0f, m_playerMaxVelocity, currentSpeed);

            //Making transition between 0 and 1 smoother.
            speedPercentage = Mathf.SmoothStep(0, 1, speedPercentage);

            //Update camera zoom.
            m_vCam.m_Lens.OrthographicSize = Mathf.Lerp(12.32f, 20.0f, speedPercentage);
            
        }
    }

}
