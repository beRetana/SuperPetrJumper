using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PetrManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay, highScoreDisplay;
    [SerializeField] private Animator animator;
    [SerializeField] private float sonicSpeed, sonicSpeedDuration, duration, scoreIncrease, delayedDead;
    private PetrControllers playerControls;
    private bool spiderPowerUp, sonicPowerUp, gojoPowerUp, dead;
    private float score, coinScore, defaultSpeed;
    public TextMeshProUGUI ScoreDisplay {get{return scoreDisplay;}}
    public bool Death { get { return dead; } }
    public bool SpiderPowerUp { get { return spiderPowerUp; } }

    public void Dead()
    {
        if (!gojoPowerUp)
        {
            MusicManager.Music.PlaySFX("PetrDied");
            dead = true;
            DefaultSettings();
            animator.SetBool("Dead", true);
            Invoke(nameof(DelayedDeath), delayedDead);
        }
    }

    private void DelayedDeath()
    {
        GameStateManager.GameOver(score + coinScore);
    }

    private void Start()
    {
        highScoreDisplay.text = $"<b>{GameStateManager.highestScore}</b>";
        defaultSpeed = Time.timeScale;
    }

    private void Update()
    {
        score = Mathf.Round(Time.timeSinceLevelLoad * 10);
        scoreDisplay.text = $"<b>{score + coinScore}</b>";
    }

    public void Coins()
    {
        coinScore += scoreIncrease;
        MusicManager.Music.PlaySFX("PickedCoin");
        scoreDisplay.text = $"<b>{score + coinScore}</b>";
    }

    private void DefaultSettings()
    {
        //Turns the player's settings into the default.
        animator.SetBool("Gojo", false);
        animator.SetBool("Sonic", false);
        animator.SetBool("SpiderMan", false);
        Time.timeScale = defaultSpeed;
        gojoPowerUp = false;
        spiderPowerUp = false;
    }

    private void PowerDown()
    {
        MusicManager.Music.PlaySFX("PowerDown");
    }

    public void StartPowerUp(string powerUp)
    {
        DefaultSettings();

        if (!dead) {
            switch (powerUp)
            {
                case "Gojo":
                    gojoPowerUp = true;
                    break;

                case "Sonic":
                    Time.timeScale *= sonicSpeed;
                    break;

                default:
                    spiderPowerUp = true;
                    break;
            }
        }

        animator.SetBool(powerUp, true);
        MusicManager.Music.PlaySFX("PowerUp");
        Invoke(nameof(PowerDown), duration);
        Invoke(nameof(DefaultSettings), duration);
    }
}
