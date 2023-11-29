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

    public override void Attack(GameObject target)
    {
        if (target.CompareTag("Petr"))
        {
            Time.timeScale = 1;
            target.GetComponent<PetrManager>().Dead();
        }
        Destroy(gameObject);
    }

    public override void Move()
    {
        var squirrelDirection = ((Vector3.left * moveLeft) + (Vector3.down * moveDown)).normalized;
        transform.position += squirrelDirection * speed * Time.deltaTime;
    }
}