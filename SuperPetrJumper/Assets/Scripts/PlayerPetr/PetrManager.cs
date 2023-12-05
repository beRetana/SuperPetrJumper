using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PetrManager : MonoBehaviour
{
    [SerializeField] private PetrScore score;
    [SerializeField] private Animator animator;
    [SerializeField] private PetrHasDied deadMenu;
    [SerializeField] private float sonicSpeed, sonicSpeedDuration, duration;
    private PetrControllers playerControls;
    private bool spiderPowerUp, sonicPowerUp, gojoPowerUp, dead;
    private float defaultSpeed;
    public bool Death { get { return dead; } }
    public bool SpiderPowerUp { get { return spiderPowerUp; } }

    //Gets called when an enenmy touches the player
    public void Dead()
    {
        //Only when the player doesn't have the Gojo power-up.
        if (!gojoPowerUp)
        {
            MusicManager.Music.PlaySFX("PetrDied");
            dead = true;
            DefaultSettings();
            animator.SetBool("Dead", true);
            deadMenu.PetrCaptured();
            GameStateManager.GameScore(score.GetScore());
        }
    }

    //Records the initial default speed of the game.
    private void Start()
    {
        defaultSpeed = Time.timeScale;
    }

    //Turns the player's settings into the default.
    private void DefaultSettings()
    {
        animator.SetBool("Gojo", false);
        animator.SetBool("Sonic", false);
        animator.SetBool("SpiderMan", false);
        Time.timeScale = defaultSpeed;
        gojoPowerUp = false;
        spiderPowerUp = false;
    }

    //Plays the power-down sound effect.
    private void PowerDown()
    {
        MusicManager.Music.PlaySFX("PowerDown");
    }

    //Activates the specific power-up sent as an argument.
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
        //Adds dealy to effects. I was taught how to do coroutines.
        Invoke(nameof(PowerDown), duration);
        Invoke(nameof(DefaultSettings), duration);
    }
}
