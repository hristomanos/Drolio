using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpikes : Spikes
{

    [SerializeField] float lerpDuration = 1f;
    bool rotating = true;

    private void Start()
    {
        StartCoroutine(Rotate180());
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

        yield return new WaitForSeconds(Random.Range(2f,8f));

        StartCoroutine(Rotate180());
    }

}
