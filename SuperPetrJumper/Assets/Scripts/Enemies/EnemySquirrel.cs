using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySquirrel : MonoBehaviour
{
    [SerializeField] private float moveLeft, moveDown;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Update()
    {
        var squirrelDirection = ((Vector3.left * moveLeft) + (Vector3.down * moveDown)).normalized;
        rb.AddForce(squirrelDirection);
    }

    // Update is called once per frame
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Petr"))
        {
            //collision.gameObject.GetComponent<PetrManager>().Dead();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}