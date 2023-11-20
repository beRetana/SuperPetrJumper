using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPowerUp : MonoBehaviour
{
    [SerializeField] private GojoOverPowerUp test;
    [SerializeField] private float moveSpeed;
    private Vector3 distance;

    private void Update()
    {
        //Moves the object to the left.
        distance = Vector2.left * moveSpeed * Time.deltaTime;
        transform.position += distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Only if it collides with the player.
        if (collision.gameObject.CompareTag("Petr"))
        {
            //Calls methods to make effects into the player.
            Destroy(gameObject);
            test.ChangeSkins(collision.gameObject);
            test.ActivatePower(collision.gameObject);
        }
    }
}
