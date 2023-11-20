using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PetrManager : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private Sprite defaultSkin;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float duration;
    [SerializeField] private GameObject SpiderWebs;
    [SerializeField] private float sonicSpeed, sonicSpeedDuration;
    private PetrControllers playerControls;
    [SerializeField] private float defaultSpeed;
    private bool spiderPowerUp, sonicPowerUp, gojoPowerUp;

    private void Awake()
    {
        playerControls = new PetrControllers();
        playerControls.Petr.Enable();
        playerControls.Petr.ShootWebs.performed += ShootWebs;
    }

    private void ShootWebs(InputAction.CallbackContext context)
    {
        if (spiderPowerUp)
        {
            GameObject web = Instantiate(SpiderWebs, tr.position, Quaternion.identity);
            Destroy(web, duration);
        }
    }

    private void DefaultSkin()
    {
        sprite.sprite = defaultSkin;
    }

    private void DefaultSpider()
    {
        spiderPowerUp = false;
    }

    private void DefaultSpeed()
    {
        Time.timeScale = defaultSpeed;
    }

    public void StartSpider()
    {
        if (sonicPowerUp)
        {
            DefaultSpeed();
        }
        spiderPowerUp = true;
        Invoke(nameof(DefaultSpider), duration);
        Invoke(nameof(DefaultSkin), duration);
    }

    public void StartSonic()
    {
        Time.timeScale = sonicSpeed;
        spiderPowerUp = false;
        Invoke(nameof(DefaultSkin), sonicSpeedDuration);
        Invoke(nameof(DefaultSpeed), sonicSpeedDuration);
    }

    public void StartGojo()
    {
        spiderPowerUp = false;
        if (sonicPowerUp)
        {
            DefaultSpeed();
        }
        Invoke(nameof(DefaultSkin), duration);

    }
}
