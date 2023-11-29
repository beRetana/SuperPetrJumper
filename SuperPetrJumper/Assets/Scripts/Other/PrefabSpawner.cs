using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private float delayStartTime;
    [SerializeField] private float intervalTime;

    //Call the function SpawnPowerUp() delayStartTime after the game
    //starts and on interval of intervalTime in seconds.
    private void Start()
    {
        InvokeRepeating("SpawnPrefab", delayStartTime, intervalTime);
    }

    //Get a random number in range of zero and the length of the list
    //then initialize it.
    private void SpawnPrefab()
    {
        int random = Random.Range(0, prefabs.Count);
        Instantiate(prefabs[random]);
    }
}
