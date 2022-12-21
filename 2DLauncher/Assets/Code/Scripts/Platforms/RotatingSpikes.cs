using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpikes : Spikes
{

    [SerializeField] float lerpDuration = 1.0f;
    [SerializeField] float delay = 0.0f;


    WaitForSeconds waitBeforeRotate;

    bool isLookingUp = true;

    private void Start()
    {
        StartCoroutine(Rotate180());
        waitBeforeRotate = new WaitForSeconds(5.0f + delay);
    }


    IEnumerator Rotate180()
    {
        float timeElapsed = 0;
        float sign = -1;
        Quaternion startRotation  = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 0, sign * 180);

        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isLookingUp = !isLookingUp;
        yield return waitBeforeRotate;

        StartCoroutine(Rotate180());
    }

}
