using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private float tempTimeScale;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void ReturnToMain()
    {
        GameStateManager.GameOver();
    }

    private void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    private void OpenPauseMenu()
    {

        gameObject.SetActive(true);
        tempTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = tempTimeScale;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = tempTimeScale;
    }
}
