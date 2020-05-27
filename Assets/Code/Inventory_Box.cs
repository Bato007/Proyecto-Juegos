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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nextScene.SetActive(true);
    }

}
