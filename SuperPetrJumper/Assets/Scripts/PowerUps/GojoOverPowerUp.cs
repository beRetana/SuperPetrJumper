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

    //Activates the special power.
    public override void SpecialPower(GameObject target)
    {
        
    }
}
