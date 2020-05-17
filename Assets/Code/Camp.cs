using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{

    static private int campHP = 0;
    public GameObject box_trigger;
    

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
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        // Si es el player lo deja pasar
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }

        // Si es un zombie lo manda a volar y se quita vida
        else
        {
            campHP -= 60;
            collision.gameObject.transform.position = new Vector2(1.55f, -2.41f);
            if (campHP < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            campHP = 80;
            showCamp();
            collision.gameObject.transform.position = new Vector2(1.55f, -2.41f);

            box_trigger.GetComponent<BoxCollider2D>().enabled = true;
        }
       

    }

    private void showCamp()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

}
