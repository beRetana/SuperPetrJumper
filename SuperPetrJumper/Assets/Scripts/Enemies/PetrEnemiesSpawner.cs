using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PetrEnemiesSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count)]);
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
            Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count)]);
            nextSpawnTime = 0;
        }
    }
} 

