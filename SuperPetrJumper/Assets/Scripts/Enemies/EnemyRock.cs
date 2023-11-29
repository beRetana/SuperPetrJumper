using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRock : PetrEnemies
{
    [SerializeField] private float speed;

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
            Destroy(gameObject);
        }
    }

    public override void Move()
    {
        Vector3 movement = Vector3.left * speed;
        transform.position += movement * Time.deltaTime;
    }
}
