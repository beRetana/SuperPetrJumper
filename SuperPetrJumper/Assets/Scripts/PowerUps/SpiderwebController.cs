using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
        //Only when it collides with an object that are enemies.
        if (!collision.gameObject.CompareTag("Petr") &&
            !collision.gameObject.CompareTag("Don'tDestroy") &&
            !collision.gameObject.CompareTag("Collectable") &&
            !collision.gameObject.CompareTag("CheckPoint"))
        {
            //Destroys the object it collides with and itself.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
