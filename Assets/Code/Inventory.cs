using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool isActive;
    public GameObject player;
    public GameObject inventory;
    public GameObject shovel;
    public GameObject rock;
    private player_movement play;
    
    

    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
        isActive = false;
        play = player.GetComponent<player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isActive)
        {
            inventory.SetActive(true);
            isActive = true;
            Time.timeScale = 0.0f;
            if (!play.shovel)
                shovel.SetActive(false);
            else
                shovel.SetActive(true);
            if (!play.rock)
                rock.SetActive(false);
            else
                rock.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            inventory.SetActive(false);
            isActive = false;
            Time.timeScale = 1.0f;
        }
            
    }
}
