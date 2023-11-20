using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUpsScriptable/SonicPowerUp")]

public class SonicPowerUp : PowerUpsScriptable
{
    [SerializeField] private Sprite Skin;

    //Changes the Skin of the Player.
    public override void ChangeSkins(GameObject target)
    {
        if (target.gameObject.CompareTag("Petr"))
        {
            target.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Skin;
        }
    }

    //Turns on the Somic Power-up effects.
    public override void ActivatePower(GameObject target)
    {
        PetrManager cp = target.gameObject.GetComponent<PetrManager>();
        cp.StartSonic();
    }
}
