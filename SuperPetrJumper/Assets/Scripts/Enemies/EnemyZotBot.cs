using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyZotBot : PetrEnemies
{
    [SerializeField] private List<GameObject> projectiles;
    [SerializeField] private float speed, stopTime, delayAttack;
    private float counter = 3;
    private bool checkPoint;

    private void Update()
    {
        if (!checkPoint)
        {
            Move();
        }
    }

    public override void Move()
    {
        if (!checkPoint)
        {
            Vector3 direction = Vector2.left * speed;
            transform.position += direction * Time.deltaTime;
        }
    }

    public override void Attack(GameObject target)
    {
        Time.timeScale = 1;
        target.GetComponent<PetrManager>().Dead();
        Destroy(gameObject);
    }

    private void AfterProjectileAttack()
    {
        speed *= 2;
        checkPoint = false;
    }

    private void AttackRound()
    {
        var random = Random.Range(0, projectiles.Count);
        Instantiate(projectiles[random], transform.position, Quaternion.identity);
        counter--;
        if(counter > 0)
        {
            Invoke(nameof(AttackRound), delayAttack);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var target = collision.gameObject;

        if (target.CompareTag("Petr"))
        {
            Attack(target);
        }
        else if (target.CompareTag("CheckPoint"))
        {
            checkPoint = true;
            Invoke(nameof(AttackRound), delayAttack);
            Invoke(nameof(AfterProjectileAttack), stopTime);
        }
    }
}
