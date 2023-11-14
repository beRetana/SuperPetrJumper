using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUps;
    [SerializeField] private float delayStartTime;
    [SerializeField] private float intervalTime;

    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", delayStartTime, intervalTime);
    }

    private void SpawnPowerUp()
    {
        int random = Random.Range(0, powerUps.Count);
        Instantiate(powerUps[random]);
    }
}
