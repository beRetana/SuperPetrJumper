using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private float tempTimeScale;

    //Set the pause menu invisible at the start of the game.
    private void Start()
    {
        gameObject.SetActive(false);
    }

    //Load the main menu scene.
    private void ReturnToMain()
    {
        GameStateManager.GameOver();
    }

    //Quits the game and saves.
    private void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    //Makes the pause menu visible and saves the time scale at that time.
    private void OpenPauseMenu()
    {

        gameObject.SetActive(true);
        tempTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    //Makes the pause menu invisible and restores the time scale to its previous value.
    private void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = tempTimeScale;
    }

    //Load the game scene.
    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
