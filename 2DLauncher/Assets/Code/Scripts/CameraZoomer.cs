using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomer : MonoBehaviour
{

    Camera m_mainCamera;
    CinemachineBrain m_cinemachineBrain;
    [SerializeField] CinemachineVirtualCamera m_vCam;

    [SerializeField] PlayerMovement m_PlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
        m_cinemachineBrain = (m_mainCamera = null) ? null : GetComponent<CinemachineBrain>();
        //m_vCam = (m_cinemachineBrain = null) ? null : m_cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;
    }
    

    private void FixedUpdate()
    {
        SetOrthographicSize();
    }

    void SetOrthographicSize()
    {
        if (m_vCam != null && m_PlayerMovement != null)
        {
            float currentSpeed = Mathf.Abs(m_PlayerMovement.getVelocityY());

            float speedPercentage = Mathf.InverseLerp(0f, 32f, currentSpeed);
            speedPercentage = Mathf.SmoothStep(0, 1, speedPercentage);
            m_vCam.m_Lens.OrthographicSize = Mathf.Lerp(12.32f, 20.0f, speedPercentage);
            
        }
    }

}
