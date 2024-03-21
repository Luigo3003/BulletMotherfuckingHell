using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;

    public GameObject[] EnemyTypes;
    void Start()
    {
        SpawnAnEnemy();
    }

    public void SpawnAnEnemy()
    {
        int RandomSpawnPoint = Random.Range(0, SpawnPoints.Length);
        int RandomEnemy = Random.Range(0, EnemyTypes.Length);
        GameObject EnemyToSpawn = EnemyTypes[RandomEnemy];
        Instantiate(EnemyToSpawn, SpawnPoints[RandomSpawnPoint]);
        EnemyToSpawn.SetActive(true);
    }
}
