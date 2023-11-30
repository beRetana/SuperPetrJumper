using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Game;
    public static float highestScore;

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

    public static void GameOver(float score)
    {
        if (score > highestScore)
        {
            highestScore = score;
        }
        SceneManager.LoadScene("Menu");
    }
}
