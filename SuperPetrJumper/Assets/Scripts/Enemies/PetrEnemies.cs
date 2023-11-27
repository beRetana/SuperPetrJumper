using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PetrEnemies : MonoBehaviour
{
    public float enemySpeed = 2;
    // Start is called before the first frame update
    void Update()
    {
        transform.position = transform.position + (Vector3.left * enemySpeed) * Time.deltaTime;
    }

    // Update is called once per frame
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
