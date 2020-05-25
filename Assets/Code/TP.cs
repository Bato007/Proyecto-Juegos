using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public GameObject tp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tp.SetActive(true);
        if (tag.Equals("TPL"))
            collision.transform.position = new Vector3(8.35f, -2.573175f, 0.0f);
        else if (tag.Equals("TPR"))
            collision.transform.position = new Vector3(-8.35f, -2.573175f, 0.0f);

        
    }
}
