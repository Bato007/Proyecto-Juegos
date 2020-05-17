using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Box : MonoBehaviour
{

    public GameObject nextScene;

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
        nextScene.GetComponent<BoxCollider2D>().enabled = true;
    }
}
