using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public bool ObsCollision = false;
    public float maxTime = 300f; 
    public float currentDownTime;
    public float currentUpTime = 0;
    public float score;
    public bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public GameObject GameOver;
    public GameObject QuitButton;

   
    





    public void Start()
    {
        currentDownTime = maxTime;
        
        GameOver.SetActive(false);
        QuitButton.SetActive(false);
        
    }
    


    void Update()
    {
        Timer();
        string v = "Score: " + score;
        scoreText.text = v;

        gameOverHandle();



    }
    
    


    void Timer()     //timer and score calculation 
    {
        if (!gameOver)
        {
            currentDownTime -= Time.deltaTime;
            currentUpTime = Time.time;
            if (currentDownTime < 0)
            {
                currentDownTime = 0;
            }
            score = Mathf.Max(0, maxTime - currentUpTime) * (currentDownTime * 10);
           
        }
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Game Started"); 
        
    } 
    /////all collision detecions and flags ////
    ///
   
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            ObsCollision = true;
            currentDownTime -= 3;
           
        }
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            gameOver = true;
            
            GameOver.SetActive(true);
            QuitButton.SetActive(true);

            
            
        }
    }
     public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            ObsCollision=false;
            
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    public void gameOverHandle()
    {
        if (gameOver)
        {
            GameOver.SetActive(true);
            QuitButton?.SetActive(true);
            Time.timeScale = 0f;

        }
    }

}
