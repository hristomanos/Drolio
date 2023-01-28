using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomTrigger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_vCam;

    [SerializeField] float m_TargetZoom = 20;
    [SerializeField] float m_Speed = 30;
    

    bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    { 
    }

    private void Update()
    {
        //m_targetZoom -= Input.mouseScrollDelta.y * 1;
        //m_targetZoom = Mathf.Clamp(m_targetZoom, m_minZoom, m_maxZoom);
        if (isTriggered)
        {
            float newSize = Mathf.MoveTowards(m_vCam.m_Lens.OrthographicSize, m_TargetZoom, m_Speed * Time.deltaTime);
            m_vCam.m_Lens.OrthographicSize = newSize;


            if (newSize == m_TargetZoom)
            {
                isTriggered = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // m_StartZoom = m_vCam.m_Lens.OrthographicSize;
        // m_vCam.m_Lens.OrthographicSize = Mathf.Lerp(m_StartZoom, m_EndZoom, speedPercentage);
        if (collision.CompareTag("Player"))
        {
            isTriggered = true;
        }

    }
}
