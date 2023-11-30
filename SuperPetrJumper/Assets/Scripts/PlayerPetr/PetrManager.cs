using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PetrManager : MonoBehaviour
{
    [SerializeField] private GameObject SpiderWebs;
    [SerializeField] private TextMeshProUGUI scoreDisplay, highScoreDisplay;
    [SerializeField] private float sonicSpeed, sonicSpeedDuration, defaultSpeed, duration, spiderwebSpawn, scoreIncrease;
    [SerializeField] private Animator animator;
    private PetrControllers playerControls;
    private bool spiderPowerUp, sonicPowerUp, gojoPowerUp;
    private float score, coinScore;
    public TextMeshProUGUI ScoreDisplay {get{return scoreDisplay;}}

    public void Dead()
    {
        if (!gojoPowerUp)
        {
            MusicManager.Music.PlaySFX("PetrDied");
            Invoke(nameof(DelayedDeath), .5f);
        }
    }

    private void DelayedDeath()
    {
        GameStateManager.GameOver(score + coinScore);
    }

    private void Start()
    {
        highScoreDisplay.text = $"<b>{GameStateManager.highestScore}</b>";
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

    private void Awake()
    {
        //Initialize and enable the input system for Player.
        playerControls = new PetrControllers();
        playerControls.Petr.Enable();
        playerControls.Petr.ShootWebs.performed += ShootWebs;
    }

    private void ShootWebs(InputAction.CallbackContext context)
    {
        //Only initializes a SpiderWeb projectile when the
        //player has the spiderman power-up.
        if (spiderPowerUp)
        {
            Vector3 distance = Vector3.right * spiderwebSpawn;
            GameObject web = Instantiate(SpiderWebs, (transform.position + distance), Quaternion.identity);
            Destroy(web, duration);
        }
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

        switch (powerUp)
        {
            case "Gojo":
                gojoPowerUp = true;
                break;

            case "Sonic":
                Time.timeScale = sonicSpeed;
                break;

            default:
                spiderPowerUp = true;
                break;
        }

        animator.SetBool(powerUp, true);
        MusicManager.Music.PlaySFX("PowerUp");
        Invoke(nameof(PowerDown), duration);
        Invoke(nameof(DefaultSettings), duration);
    }
}
