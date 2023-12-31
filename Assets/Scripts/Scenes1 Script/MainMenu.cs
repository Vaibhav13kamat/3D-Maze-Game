using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        // Specify the index of the scene you want to reload (assuming '1' is the index of your desired scene)
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
    public void settingsButton()
    {
        SceneManager.LoadScene(2);
    }
    public void quitButton()
    {
        Application.Quit();
    }
    
}
