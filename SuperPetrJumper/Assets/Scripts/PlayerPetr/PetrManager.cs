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
    private PetrControllers playerControls;
    [SerializeField] private float defaultSpeed;
    private bool spiderPowerUp, sonicPowerUp, gojoPowerUp;

    public void Dead()
    {
        GameStateManager.GameOver();
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

    private void DefaultSkin()
    {
        //Turns the player's skin into the default.
        sprite.sprite = defaultSkin;
    }

    private void DefaultSpider()
    {
        //Turns the spiderman power-up off.
        spiderPowerUp = false;
    }

    private void DefaultSpeed()
    {
        //It turns the time speed of the game to default.
        Time.timeScale = defaultSpeed;
    }

    public void StartSpider()
    {
        //If the sonic power up is on the turn it off by
        //setting time seed back to normal.
        if (sonicPowerUp)
        {
            DefaultSpeed();
        }

        //Sets duration of the powers to "duration."
        spiderPowerUp = true;
        Invoke(nameof(DefaultSpider), duration);
        Invoke(nameof(DefaultSkin), duration);
    }

    public void StartSonic()
    {
        //Sets time speed faster and sets duration for the power up.
        Time.timeScale = sonicSpeed;
        spiderPowerUp = false;
        Invoke(nameof(DefaultSkin), sonicSpeedDuration);
        Invoke(nameof(DefaultSpeed), sonicSpeedDuration);
    }

    public void StartGojo()
    {
        //Sets duration for the skin to change back to normal.
        //Power up effects need to be done.
        spiderPowerUp = false;

        //If the sonic power up is on the turn it off by
        //setting time seed back to normal.
        if (sonicPowerUp)
        {
            DefaultSpeed();
        }
        Invoke(nameof(DefaultSkin), duration);

    }
}
