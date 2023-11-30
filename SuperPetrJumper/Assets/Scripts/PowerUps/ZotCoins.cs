using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZotCoins : MonoBehaviour
{
    [SerializeField] private float speed, randomChangeRange;


    private void Start()
    {
        float randomChangePosition = Random.Range(-randomChangeRange, randomChangeRange);
        transform.position += Vector3.up * randomChangePosition;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 distance = Vector2.left * speed;
        transform.position += distance * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Petr"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PetrManager>().Coins();
        }
    }
}
