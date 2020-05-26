using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Runner : MonoBehaviour
{
    public Transform playerTank;
    public float cameraDistance = 1;

    void Awake()
    {
    }
    void Update()
    {
        /*Boundaries*/
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, 3f), Mathf.Clamp(transform.position.y, 0f, 0f), transform.position.z);
    }
    void FixedUpdate()
    {
        /*Position while player walks*/
        transform.position = new Vector3(playerTank.position.x, playerTank.position.y, transform.position.z);
    }
}
