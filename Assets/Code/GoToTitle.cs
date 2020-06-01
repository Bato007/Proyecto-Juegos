using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour
{
    public GameObject text;
    public GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TitleChange(int done)
    {
        if (done == 1)
            SceneManager.LoadScene(0);
    }
    public void Congratulations()
    {
        back.SetActive(false);
        text.SetActive(true);

    }
}
