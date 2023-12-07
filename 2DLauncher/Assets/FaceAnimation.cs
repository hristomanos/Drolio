using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAnimation : MonoBehaviour
{
    //1. I want to know where the player is moving towards
    // - RigidBody velocity is a 3d vector
    //2. I want to know the limit of my pupils
    //3. Maybe lerp from one vector to the next?
    //4. Animate blinking when idle


    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] GameObject left_Pupil;
    [SerializeField] GameObject right_Pupil;

    Vector3 rightEyeLimitTopLeft;
    Vector3 leftEyeLimitTopLeft;

    Vector3 originalLeftEyePos;
    Vector3 originalRightEyePos;

    // Start is called before the first frame update
    void Start()
    {
        rightEyeLimitTopLeft = new Vector3(-0.3434297f, 0.1843705f, 0.0f);
        leftEyeLimitTopLeft = new Vector3(-0.3434296f, 0.183749f, 0.0f);

        originalLeftEyePos = left_Pupil.transform.localPosition;
        originalRightEyePos = right_Pupil.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        LookDown();
        LookUp();
        LookLeft();
        LookRight();
    }

    private void LookRight()
    {
        if ( rigidbody.velocity.x > 0 )
        {
            left_Pupil.transform.localPosition = new Vector3(0.2f, 0.0f);
            right_Pupil.transform.localPosition = new Vector3(0.2f, 0.0f);
        }
    }

    private void LookLeft()
    {
        if ( rigidbody.velocity.x < 0 )
        {
            left_Pupil.transform.localPosition = new Vector3(-0.2f, 0.0f);
            right_Pupil.transform.localPosition = new Vector3(-0.2f, 0.0f);
        }
    }

    private void LookUp()
    {
        if ( rigidbody.velocity.y > 0 )
        {
            left_Pupil.transform.localPosition = new Vector3(0.0f, leftEyeLimitTopLeft.y);
            right_Pupil.transform.localPosition = new Vector3(0.0f, rightEyeLimitTopLeft.y);
        }
    }

    private void LookDown()
    {
        if ( rigidbody.velocity.y < 0 )
        {
            left_Pupil.transform.localPosition = new Vector3(0.0f, -leftEyeLimitTopLeft.y);
            right_Pupil.transform.localPosition = new Vector3(0.0f, -rightEyeLimitTopLeft.y);
        }
    }
}
