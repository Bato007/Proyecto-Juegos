using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public AudioSource ambiental;
    // Start is called before the first frame update
    void Start()
    {
        ambiental.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

}
