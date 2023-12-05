using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager game;
    public static float highestScore = PlayerPrefs.GetFloat("HighScore", 0f);

    //Creates a singleton for the game.
    private void Awake()
    {
        if (game != null)
        {
            Destroy(gameObject);
        }
        else
        {
            game = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //Stores the game score if its higher than previous highest score.
    public static void GameScore(float score)
    {
        if (score > highestScore)
        {
            highestScore = score;
        }
    }

    //Saves the highest score, stops music and returns to main menu.
    public static void GameOver()
    {
        PlayerPrefs.SetFloat("HighScore", highestScore);
        PlayerPrefs.Save();
        MusicManager.Music.MusicSource.Stop();
        SceneManager.LoadScene("Menu");
    }
}
