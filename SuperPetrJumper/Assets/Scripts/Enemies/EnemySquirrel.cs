using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySquirrel : MonoBehaviour
{
    public float squirrelSpeed = 1f;
    Rigidbody2D rbs;
    // Start is called before the first frame update
    void Update()
    {
        var squirrelDirection = (Vector3.left + Vector3.down).normalized;
        rbs.velocity = squirrelDirection * squirrelSpeed;
    }

    // Update is called once per frame
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}