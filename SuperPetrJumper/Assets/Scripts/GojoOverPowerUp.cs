using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PowerUpsScriptable/GojoOverPowerUp")]

public class GojoOverPowerUp : PowerUpsScriptable
{
    [SerializeField] private Sprite GojoSkin;

    public override void ChangeSkins (GameObject target)
    {
        target.GetComponentInChildren<SpriteRenderer>().sprite = GojoSkin;
    }

    public override void SpecialPower(GameObject target)
    {
        
    }
}
