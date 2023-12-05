using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string scenename;

    //Load the game scene.
    private void PlayGame()
    {
        SceneManager.LoadScene(scenename);
        Time.timeScale = 1;
    }

    //Quit the game and save.
    private void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
