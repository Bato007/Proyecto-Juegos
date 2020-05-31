using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Box : MonoBehaviour
{

    public GameObject nextScene;
    public GameObject ui; 

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
        ui.SetActive(true);

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ui.SetActive(false);
        nextScene.SetActive(true);
    }

}
