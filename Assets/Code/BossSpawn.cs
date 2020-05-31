using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    
    private int hpBoss;
    public GameObject credits;
    public GameObject[] positions;
    public GameObject prefab;
    private GameObject newObj;
    private int place;

    // Start is called before the first frame update
    void Start()
    {
        place = 0;
        hpBoss = 5;
        newObj = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        place = (place == 2) ? 0 : place;

        if (!newObj)
        {
            if (hpBoss > 0)
            {
                newObj = Instantiate(prefab, positions[place].transform.position, Quaternion.identity);
                hpBoss--;
                place++;
            }
            else
            {
                credits.SetActive(true);
            }
        } 
    }
}
