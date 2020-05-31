using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{

    System.Random r = new System.Random();

    public GameObject spawn;
    Vector3 startPosition;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int index = r.Next(0, 2);
        startPosition = spawn.transform.position;
        Instantiate(prefab, startPosition, Quaternion.identity);
    }
}
