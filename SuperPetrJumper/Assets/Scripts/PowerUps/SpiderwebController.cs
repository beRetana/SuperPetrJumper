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
        //Moves web to the right.
        rb.AddForce(Vector2.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Only when it collides with an object that doesn't have the tag "Petr".
        if (!collision.gameObject.CompareTag("Petr"))
        {
            //Destroys the object it collides with and itself.
            Destroy(collision.gameObject);
            Debug.Log("HitRock");
            Destroy(gameObject);
        }
    }
}
