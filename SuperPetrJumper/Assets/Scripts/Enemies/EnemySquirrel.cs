using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySquirrel : MonoBehaviour
{
    [SerializeField] private float speed, moveLeft, moveDown;
    // Start is called before the first frame update
    void Update()
    {
        var squirrelDirection = ((Vector3.left * moveLeft) + (Vector3.down * moveDown)).normalized;
        transform.position += squirrelDirection * speed * Time.deltaTime;
    }

    // Update is called once per frame
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Petr"))
        {
            Time.timeScale = 1;
            collision.gameObject.GetComponent<PetrManager>().Dead();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}