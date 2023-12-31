using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;



public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject pause;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pause.SetActive(true);

    }
    



    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1f;
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
