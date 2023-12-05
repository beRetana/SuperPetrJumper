using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySquirrel : PetrEnemies
{
    [SerializeField] private float speed, moveLeft, moveDown;
    
    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attack(collision.gameObject);
    }

    //If it hits the player then it destroys the enemy and ends the game.
    public override void Attack(GameObject target)
    {
        if (target.CompareTag("Petr"))
        {
            target.GetComponent<PetrManager>().Dead();
            Destroy(gameObject);
        }
    }

    //Makes the squirrel move to the left downwards in a diagonal trajectory.
    public override void Move()
    {
        var squirrelDirection = ((Vector3.left * moveLeft) + (Vector3.down * moveDown)).normalized;
        transform.position += squirrelDirection * speed * Time.deltaTime;
    }
}