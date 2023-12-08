using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    float timeBetweenSpawns;
    [SerializeField] float startTimeBetweenSpawns;
    [SerializeField] GameObject echo;

    Stomp stomp;

    private void Start()
    {
        stomp = GetComponent<Stomp>();
    }


    private void Update()
    {
        if ( stomp.ButtonPressed )
        {
            if ( timeBetweenSpawns <= 0 )
            {
                GameObject instance = Instantiate(echo,transform.position,Quaternion.identity);
                Destroy(instance, 5f);
                stomp.ButtonPressed = false;
                timeBetweenSpawns = startTimeBetweenSpawns;
            }
            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
    }
}
