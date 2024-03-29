using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int ammountToPool;


    private void Awake()
    {
        SharedInstance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for ( int i = 0; i < ammountToPool; i++ )
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for ( int i = 0; i < ammountToPool; i++ )
        {
            if ( !pooledObjects[i].activeInHierarchy )
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
