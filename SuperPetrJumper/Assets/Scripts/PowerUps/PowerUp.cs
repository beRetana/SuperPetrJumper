using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Wanted to learn how to use scriptable objects even though I think
  that using an abstract class would have been more efficient*/

[CreateAssetMenu (menuName = "PowerUpsScriptable/PowerUp")]

public class PowerUp : PowerUpsScriptable
{
    //Changes the Skin of the Player.
    public override void ChangeSkins (GameObject target, Sprite skin)
    {
        target.GetComponentInChildren<SpriteRenderer>().sprite = skin;
    }

    //Activates the power-up for player.
    public override void ActivatePower(GameObject target, string powerUp)
    {
        target.gameObject.GetComponent<PetrManager>().StartPowerUp(powerUp);
    }
}
