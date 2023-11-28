using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
    [SerializeField] private PowerUp powerUp;
    [SerializeField] private Sprite skin;
    [SerializeField] private float moveSpeed;
    [SerializeField] private string powerUpName;
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
            powerUp.ChangeSkins(collision.gameObject, skin);
            powerUp.ActivatePower(collision.gameObject, powerUpName);
        }
    }
}
