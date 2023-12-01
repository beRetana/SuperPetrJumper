using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroys any object that has the tag "PowerUps"
        var target = collision.gameObject;
        if (!target.CompareTag("Petr") &&
            !target.CompareTag("Don'tDestroy") &&
            !target.CompareTag("Ground"))
        {
            Destroy(target);
        }
    }
}
