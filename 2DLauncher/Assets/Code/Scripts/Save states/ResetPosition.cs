using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    Vector3 m_ResetPosition;

    private void Start()
    {
        m_ResetPosition = transform.localPosition;
    }


    private void OnDisable()
    {
        transform.localPosition = m_ResetPosition;
        transform.localRotation = Quaternion.identity;
    }
}
