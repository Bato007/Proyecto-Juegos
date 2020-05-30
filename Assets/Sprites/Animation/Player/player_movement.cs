using System.Collections;
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
    public bool shovel = false;
    public bool rock = false;
    public GameObject wp;
    private int bullets = 0;
    private int maxSpeed = 2;
    public float jumpForce = 5.0f;

   

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
            if (shovel)
            {
                animator.SetBool("Shovel", true);
                if (SceneManager.GetActiveScene().buildIndex == 3)
                    CheckTreasure();
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


        //Para cuando salte
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            Jump();
        }

        if (rb)
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0));



    }
    void FixedUpdate()
    {
        //Se mueve a los lados

        

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));



       



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
        if (Mathf.Abs(rb.velocity.y) < 0.005f && Time.timeScale>0.0f)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void CheckTreasure()
    {
        if(transform.position.x > 1.06 && transform.position.x < 2.6)
        {
            bullets++;
            wp.SetActive(false);

        }

    }

   

}
