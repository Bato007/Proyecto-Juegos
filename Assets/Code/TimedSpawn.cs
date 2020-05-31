using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{

    public GameObject spawne;
    public bool stopSpawn = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Instantiate(spawne, gameObject.transform.position, Quaternion.identity);
        if(stopSpawn == true)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
