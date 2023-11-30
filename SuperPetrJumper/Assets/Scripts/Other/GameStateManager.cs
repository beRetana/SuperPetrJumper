using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager game;
    public static float highestScore;

    private void Awake()
    {
        if(game != null)
        {
            Destroy(gameObject);
        }
        else
        {
            game = this;
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
        MusicManager.Music.MusicSource.Stop();
    }
}
