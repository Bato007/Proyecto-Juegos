using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Se escucha el sonido del zombie en la ventana
        if (collision.gameObject.CompareTag("ZombieFX"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
