using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectiles : MonoBehaviour
{
    [SerializeField] private float gravity, speed, upForce;
    private bool started;
    private Vector3 distance;

    private void Update()
    {
        //Adds upwards force to the projectile once right after it has been instantiated.
        if (!started)
        {
            distance = Vector2.up * upForce;
            started = true;
        }

        //Makes the projectile move to the left and down in a angular trajectory.
        distance.x += speed * Time.deltaTime;
        distance.y += gravity * Time.deltaTime;
        transform.position += distance * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.gameObject;

        //If it hits the player then it destroys the projectile and ends the game.
        if (target.CompareTag("Petr"))
        {
            Destroy(gameObject);
            target.GetComponent<PetrManager>().Dead();
        }
    }
}
