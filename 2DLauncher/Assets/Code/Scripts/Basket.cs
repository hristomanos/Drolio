using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Basket : MonoBehaviour
{
    CinemachineImpulseSource screenShake;
    float timeSpeed = 1; 
    private void Start()
    {
        screenShake = GetComponent<CinemachineImpulseSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            screenShake.GenerateImpulse();
            timeSpeed = 0.5f;
            Handheld.Vibrate();
        }
    }

    private void Update()
    {
        Time.timeScale = timeSpeed;
    }
}
