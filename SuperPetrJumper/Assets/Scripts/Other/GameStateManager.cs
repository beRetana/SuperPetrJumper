using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Game;

    private void Awake()
    {
        if(Game != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Game = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }
}
