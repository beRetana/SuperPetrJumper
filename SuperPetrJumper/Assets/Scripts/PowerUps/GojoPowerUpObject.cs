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
        distance = Vector2.left * moveSpeed * Time.deltaTime;
        transform.position += distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Petr"))
        {
            Destroy(gameObject);
            test.ChangeSkins(collision.gameObject);
        }
    }
}
