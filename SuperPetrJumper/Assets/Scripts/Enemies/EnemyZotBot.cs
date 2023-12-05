using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyZotBot : PetrEnemies
{
    [SerializeField] private List<GameObject> projectiles;
    [SerializeField] private float speed, stopTime, delayAttack, counter, increaseSpeed;
    private bool checkPoint;

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        //If its if the check point stops moving to the left.
        if (!checkPoint)
        {
            Vector3 direction = Vector2.left * speed;
            transform.position += direction * Time.deltaTime;
        }
    }

    //Destroys the ZotBot and ends the game.
    public override void Attack(GameObject target)
    {
        Destroy(gameObject);
        target.GetComponent<PetrManager>().Dead();
    }

    //It allows for the ZotBot to move to the left faster.
    private void AfterProjectileAttack()
    {
        speed *= increaseSpeed;
        checkPoint = false;
    }

    private void AttackRound()
    {
        //Chooses a random food and instantiates it.
        var random = Random.Range(0, projectiles.Count);
        Instantiate(projectiles[random], transform.position, Quaternion.identity);
        counter--;

        //Recourse the attack until counter is equal or less than zero.
        if (counter > 0)
        {
            //This is used to create a delayed. I couldn't learn to use coroutines.
            Invoke(nameof(AttackRound), delayAttack);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.gameObject;

        //If it hits the player it attacks
        if (target.CompareTag("Petr"))
        {
            Attack(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var target = collision.gameObject;

        //If it exits the check point then attack and rage forward.
        if (target.CompareTag("CheckPoint"))
        {
            checkPoint = true;
            Invoke(nameof(AttackRound), delayAttack);
            Invoke(nameof(AfterProjectileAttack), stopTime);
        }
    }
}
