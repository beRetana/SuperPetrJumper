using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderwebController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        rb.AddForce(Vector2.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Petr"))
        {
            Destroy(collision.gameObject);
        }
    }
}
