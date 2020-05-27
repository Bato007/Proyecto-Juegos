using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camp : MonoBehaviour
{

    static private int campHP = 0;
    public GameObject box_trigger;
    public GameObject option;
    

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        option.SetActive(true);

        if (collision.gameObject.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.R)){
                gameObject.GetComponent<AudioSource>().Play();
                campHP = 80;
                showCamp();
                collision.gameObject.transform.position = new Vector2(1.55f, -2.41f);

                box_trigger.GetComponent<BoxCollider2D>().enabled = true;
            } else if (Input.GetKeyDown(KeyCode.F)) 
            {
                campHP = 60;
                showCamp();
                collision.gameObject.transform.position = new Vector2(1.55f, -2.41f);

                box_trigger.GetComponent<BoxCollider2D>().enabled = true;
            }
            
        }
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        option.SetActive(false);    
    }

    private void showCamp()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

}
