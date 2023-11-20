using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUpsScriptable/SpidermanPowerUp")]

public class SpidermanPowerUp : PowerUpsScriptable
{
    [SerializeField] private Sprite Skin;

    public override void ChangeSkins(GameObject target)
    {
        target.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Skin;
    }

    public override void ActivatePower(GameObject target)
    {
        PetrManager cp = target.gameObject.GetComponent<PetrManager>();
        cp.StartSpider();
    }
}
