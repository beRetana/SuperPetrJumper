using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PetrManager : MonoBehaviour
{
    [SerializeField] private Sprite defaultSkin;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float duration;
    [SerializeField] private GameObject SpiderWebs;
    [SerializeField] private float sonicSpeed, sonicSpeedDuration;
    [SerializeField] private Animator animator;
    private PetrControllers playerControls;
    [SerializeField] private float defaultSpeed;
    private bool spiderPowerUp, sonicPowerUp, gojoPowerUp;

    public void Dead()
    {
        if (!gojoPowerUp)
        {
            GameStateManager.GameOver();
        }
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
            GameObject web = Instantiate(SpiderWebs, transform.position, Quaternion.identity);
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

    public void StartSpider()
    {
        DefaultSettings();

        //Sets duration of the powers to "duration."
        spiderPowerUp = true;

        animator.SetBool("SpiderMan", true);
        Invoke(nameof(DefaultSettings), duration);
    }

    public void StartSonic()
    {
        //Sets time speed faster and sets duration for the power up.
        DefaultSettings();
        Time.timeScale = sonicSpeed;
        animator.SetBool("Sonic", true);
        Invoke(nameof(DefaultSettings), sonicSpeedDuration);
    }

    public void StartGojo()
    {
        DefaultSettings();

        //Sets duration for the skin to change back to normal.
        //Power up effects need to be done.
        gojoPowerUp = true;
        animator.SetBool("Gojo", true);
        Invoke(nameof(DefaultSettings), duration);
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
        Invoke(nameof(DefaultSettings), duration);
    }
}
