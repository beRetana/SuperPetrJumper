using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUps;
    [SerializeField] private float delayStartTime;
    [SerializeField] private float intervalTime;

    //Call the function SpawnPowerUp() delayStartTime after the game
    //starts and on interval of intervalTime in seconds.
    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", delayStartTime, intervalTime);
    }

    //Get a random number in range of zero and the length of the list
    //then initialize it.
    private void SpawnPowerUp()
    {
        int random = Random.Range(0, powerUps.Count);
        Instantiate(powerUps[random]);
    }
}
