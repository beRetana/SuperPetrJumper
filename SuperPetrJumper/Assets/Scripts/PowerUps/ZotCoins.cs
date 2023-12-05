using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZotCoins : MonoBehaviour
{
    [SerializeField] private float speed, randomChangeRange;

    //Changes the object to a random position within the range given.
    private void Start()
    {
        float randomChangePosition = Random.Range(-randomChangeRange, randomChangeRange);
        transform.position += Vector3.up * randomChangePosition;
    }

    private void Update()
    {
        Move();
    }

    //Moves the ZotCoin to the left.
    private void Move()
    {
        Vector3 distance = Vector2.left * speed;
        transform.position += distance * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*If it collider with the player it should call the method coins to add
         increase the game score.*/
        if (collision.gameObject.CompareTag("Petr"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PetrScore>().Coins();
        }
    }
}
