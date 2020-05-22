﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public LayerMask groundLayer;
    public GameObject arrow;
    private bool isJumping = false;
    private bool shovel = false;
    private bool rock = false;

    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {
        //Se obtiene la velocidad en x (y no se necesitara)

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Se revisa si hay una tecla presionada
        if (Input.GetButtonDown("Throw"))
        {
            if (rock)
            {
                animator.SetBool("Rock", true);
            }
        } else
        {
            animator.SetBool("Rock", false);
        }

        if (Input.GetButtonDown("Dig"))
        {
            if (rock)
            {
                animator.SetBool("Shovel", true);
            }
        }
        else
        {
            animator.SetBool("Shovel", false);
        }




        //Se cambia la escala del personaje dependiendo de la direccion a la que vaya
        Vector3 charScale = transform.localScale;
        if (movement.x == -1)
        {
            charScale.x = -0.1f;
        }
        if (movement.x == 1)
        {
            charScale.x = 0.1f;
        }
        transform.localScale = charScale;


        //Se cambia la animacion
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        
    }
    void FixedUpdate()
    {
        //Se mueve si no es salto
        if(movement.y != 1)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        



        //Para cuando salte
        if (Input.GetKeyDown(KeyCode.Space) || movement.y == 1) {
                isJumping = true;
                Jump();
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isJumping)
        {
            if (other.gameObject.CompareTag("Grada_Abajo"))
            {
                gameObject.transform.position = new Vector2(10.78f, 1.92f);
            }
            else if (other.gameObject.CompareTag("Grada_Arriba"))
            {
                gameObject.transform.position = new Vector2(5.07f, -3.15f);
            }
            isJumping = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerItem"))
        {
            if (collision.gameObject.name == "Rock")
            {
                rock = true;
                Destroy(collision.gameObject);
            } else if (collision.gameObject.name == "Shovel")
            {
                shovel = true;
                Destroy(collision.gameObject);
            }
        }

        if (arrow)
        {
            if (shovel && rock)
            {
                arrow.SetActive(true);
                if (collision.gameObject.CompareTag("Arrow"))
                {
                    //Si ya tiene ambos items, pasar a la siguiente escena
                    SceneManager.LoadScene(3);
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    private void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.05f)
            rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
    }

}
