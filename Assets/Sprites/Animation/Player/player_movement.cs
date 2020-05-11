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

    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {
        //Se obtiene la velocidad en x (y no se necesitara)
        movement.x = Input.GetAxisRaw("Horizontal");
        //Se cambia la animacion
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }
    void FixedUpdate()
    {
        //Se mueve
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Raycast para cuando salte
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, groundLayer);

        //Para cuando salte
        if (hit.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
            }
        }

    }
}
