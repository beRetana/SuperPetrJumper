using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUpsScriptable/SpidermanPowerUp")]

public class SpidermanPowerUp : PowerUpsScriptable
{
    [SerializeField] private Sprite Skin;

    //Changes the skin of the player.
    public override void ChangeSkins(GameObject target)
    {
        target.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Skin;
    }

    //Turns on the Spiderman Power-up effects.
    public override void ActivatePower(GameObject target)
    {
        PetrManager cp = target.gameObject.GetComponent<PetrManager>();
        cp.StartSpider();
    }
}
