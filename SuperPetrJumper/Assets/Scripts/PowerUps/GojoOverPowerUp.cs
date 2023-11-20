using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PowerUpsScriptable/GojoOverPowerUp")]

public class GojoOverPowerUp : PowerUpsScriptable
{
    [SerializeField] private Sprite GojoSkin;

    //Changes the Skin of the Player.
    public override void ChangeSkins (GameObject target)
    {
        target.GetComponentInChildren<SpriteRenderer>().sprite = GojoSkin;
    }

    //Activates the Gojo power-up for player.
    public override void ActivatePower(GameObject target)
    {
        PetrManager cp = target.gameObject.GetComponent<PetrManager>();
        cp.StartGojo();
    }
}
