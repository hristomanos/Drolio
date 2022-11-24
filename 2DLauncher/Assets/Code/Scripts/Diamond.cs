using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DiamondCounter.instance.AddADiamond();
        AudioManager.instance.PlaySound("Diamond");
        Destroy(gameObject);
    }

}
