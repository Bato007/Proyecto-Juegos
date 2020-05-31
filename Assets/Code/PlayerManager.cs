using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject prefab;
    private GameObject newObj;

    // Start is called before the first frame update
    void Start()
    {
        newObj = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!newObj)
        {
            gameOver.SetActive(true);
        }
    }
}
