using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider sensitivitySlider;
    
    // Start is called before the first frame update
    public void UpdateSensitivity()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            // Update the sensitivity value based on the slider value (between 1 to 100)
            playerController.sensitivity = sensitivitySlider.value;
        }
        else
        {
            Debug.LogWarning("PlayerController not found in the scene!");
        }




    }


    private void Start()
    {
        sensitivitySlider.onValueChanged.AddListener(delegate { UpdateSensitivity(); });
    }
    public void BackButton()   //for back button
    {
        SceneManager.LoadScene(0);
    }
    
}
