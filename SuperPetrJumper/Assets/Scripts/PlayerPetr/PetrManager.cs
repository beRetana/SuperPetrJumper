using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PetrManager : MonoBehaviour
{
    [SerializeField] private GameObject SpiderWebs;
    [SerializeField] private float sonicSpeed, sonicSpeedDuration, defaultSpeed, duration, spiderwebSpawn;
    [SerializeField] private Animator animator;
    private PetrControllers playerControls;
    private bool spiderPowerUp, sonicPowerUp, gojoPowerUp;
    private float score;

    public void Dead()
    {
        if (!gojoPowerUp)
        {
            GameStateManager.GameOver();
        }
    }

    public void Coins()
    {
        score += 10;
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
