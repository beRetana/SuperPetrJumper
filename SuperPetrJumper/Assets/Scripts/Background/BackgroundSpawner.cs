using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Checkpoint was placed in a position that only a background object can reach
  which means there was no need for a more specific tag to recognize the background object.*/

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject background;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Create a background when checkpoint collides with a background.
        if (collision.gameObject.CompareTag("Don'tDestroy"))
        {
            Instantiate(background);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroys the background when it exits the checkpoint
        if (collision.gameObject.CompareTag("Don'tDestroy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
