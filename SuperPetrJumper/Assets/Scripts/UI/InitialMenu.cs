using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string scenename;

    private void PlayGame()
    {
        SceneManager.LoadScene(scenename);
        Time.timeScale = 1;
    }

    private void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
