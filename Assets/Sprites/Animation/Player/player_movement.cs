using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public LayerMask groundLayer;
    private bool isJumping = false;

    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {
        //Se obtiene la velocidad en x (y no se necesitara)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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
        

        //Raycast para cuando salte
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, groundLayer);

        //Para cuando salte
        if (hit.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) || movement.y == 1)
            {
                isJumping = true;
                rb.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se revisa que haya intentado saltar, de lo contrario se ignora
        if (isJumping)
        {
            print("se hace");
        } else
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.GetComponent<Collider2D>());
        }
    }

}
