using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    Vector3 resetPosition;

    private void Start()
    {
        resetPosition = transform.localPosition;
    }


    private void OnDisable()
    {
        transform.localPosition = resetPosition;
        transform.localRotation = Quaternion.identity;
    }
}
