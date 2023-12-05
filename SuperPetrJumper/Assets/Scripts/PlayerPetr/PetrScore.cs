using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 
public class PetrScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay, highScoreDisplay;
    [SerializeField] private float scoreIncrease, scoreFactor;
    public TextMeshProUGUI ScoreDisplay { get { return scoreDisplay; } }
    private float score, coinScore;
    public float Score { get { return score; } }

    //Displays the highest scored saved.
    private void Start()
    {
        highScoreDisplay.text = $"<b>{PlayerPrefs.GetFloat("HighScore")}</b>";
    }

    //Increases the score by a factor of 10 per second and displays it.
    private void Update()
    {
        score = Mathf.Round(Time.timeSinceLevelLoad * scoreFactor);
        scoreDisplay.text = $"<b>{score + coinScore}</b>";
    }

    //Adds points to score when a coin is collected.
    public void Coins()
    {
        coinScore += scoreIncrease;
        MusicManager.Music.PlaySFX("PickedCoin");
        scoreDisplay.text = $"<b>{score + coinScore}</b>";
    }

    //Returns the overall score, score by time and score by coins combined.
    public float GetScore()
    {
        return coinScore + score;
    }
}
