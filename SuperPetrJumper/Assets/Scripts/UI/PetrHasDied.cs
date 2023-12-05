using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetrHasDied : MonoBehaviour
{
    private float tempTime;

    //Sets the died menu invisible at the start of the game.
    void Start()
    {
        gameObject.SetActive(false); 
    }

    //Stops time and makes the died menu visible.
    public void PetrCaptured()
    {
        tempTime = Time.timeScale;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    //Loads the main menu scene.
    public void MainMenu()
    {
        GameStateManager.GameOver();
    }

    //Loads the game scene to restart the game.
    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = tempTime;
    }
}
