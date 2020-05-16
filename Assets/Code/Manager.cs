using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    // Menu de pausa
    public GameObject pauseMenu;
    public GameObject fog;
    private bool active = false;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        // Pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pauseMenu)
        {
            fog.SetActive(!pauseMenu.activeSelf);
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            active = !active;
            Time.timeScale = active ? 0.0f : 1.0f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
