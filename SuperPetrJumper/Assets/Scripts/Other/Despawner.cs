using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroys any object that is not the player,
        //the ground or has the tag don't destroy.
        //It is meant to destroy enemies and powerUps.
        var target = collision.gameObject;
        if (!target.CompareTag("Petr") &&
            !target.CompareTag("Don'tDestroy") &&
            !target.CompareTag("Ground"))
        {
            Destroy(target);
        }
    }
}
