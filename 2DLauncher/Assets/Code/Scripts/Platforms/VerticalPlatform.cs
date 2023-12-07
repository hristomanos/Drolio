using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 10, ForceMode.Impulse);
    }
}
