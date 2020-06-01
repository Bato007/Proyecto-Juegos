using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    public AudioSource ambiental;
    // Start is called before the first frame update
    void Start()
    {
        ambiental.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Se escucha el sonido del zombie en la ventana
        if (collision.gameObject.CompareTag("ZombieFX"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
