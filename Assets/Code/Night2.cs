using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Night2 : MonoBehaviour
{
    public GameObject building;
    public Image fade;
    public GameObject arrow;

    private Boolean window1;
    private Boolean window2;
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
        if (collision.gameObject.name == "Zombie1")
        {
            StartCoroutine("Building_Window1");
            window1 = true;
            collision.gameObject.GetComponent<AudioSource>().Play();
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.gameObject.name == "Zombie2")
        {
            StartCoroutine("Building_Window2");
            window2 = true;
            collision.gameObject.GetComponent<AudioSource>().Play();
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (arrow)
        {
            if (window1 && window2)
            {
                arrow.SetActive(true);
                if (collision.gameObject.CompareTag("Arrow"))
                {
                    //Si ya tiene ambos items, pasar a la siguiente escena
                    SceneManager.LoadScene(5);
                    Destroy(collision.gameObject);
                }
            }
        }
    }


    IEnumerator Building_Window1()
    {
        building.transform.position = gameObject.transform.position;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        building.SetActive(true);
        yield return new WaitForSeconds(1f); /*Mostrando tronco*/

        fade.GetComponent<Image>().enabled = true;

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Wood1");
        foreach (GameObject wood1 in gameObjectArray)
        {
            wood1.GetComponent<SpriteRenderer>().enabled = true;
        }
        yield return new WaitForSeconds(2f); /*Mostrando pantalla negra, poniendo tablas*/

        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        building.SetActive(false);
        fade.enabled = false;                 /*Regresando a la normalidad*/
    }

    IEnumerator Building_Window2()
    {
        building.transform.position = gameObject.transform.position;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        building.SetActive(true);
        
        yield return new WaitForSeconds(1f); /*Mostrando tronco*/

        fade.GetComponent<Image>().enabled = true;

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Wood2");
        foreach (GameObject wood1 in gameObjectArray)
        {
            wood1.GetComponent<SpriteRenderer>().enabled = true;
        }
        yield return new WaitForSeconds(2f); /*Mostrando pantalla negra, poniendo tablas*/

        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        building.SetActive(false);
        fade.enabled = false;   /*Regresando a la normalidad*/
    }

}
