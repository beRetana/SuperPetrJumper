using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquirrelSpawner : MonoBehaviour
{
    
    public Rigidbody2D rbs;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(rbs);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnTime > minSpawnTime)
        {
            nextSpawnTime = minSpawnTime + Time.deltaTime;
        }
        else
        {
            Instantiate(rbs);
            nextSpawnTime = 0;
        }
    }
}