using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_movement : MonoBehaviour
{
    public LayerMask enemyLayer;
    private bool right = true;
    public float distance;
    public float speed;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>(); 
    }

    void FixedUpdate()
    {
        //Para cambiar su posicion
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D enemy = Physics2D.Raycast(tf.position, Vector2.down, distance, enemyLayer);
        //Se revisa que este en su layer
        if (enemy.collider == false)
        {
            if (right == true)
            { //Derecha
                transform.eulerAngles = new Vector3(0, -180, 0);
                right = false;
            }
            else
            { //Izquierda
                transform.eulerAngles = new Vector3(0, 0, 0);
                right = true;
            }
        }
    }
}
