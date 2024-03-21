using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour
{
    [SerializeField] private GameObject BulletPoolref;
    [SerializeField] private GameObject EnemySpawnerref;

    private float TimeAlive = 0;

    private void Awake()
    {
       BulletPoolref = GameObject.Find("BulletPoolPlayer").GetComponent<PoolScript>().gameObject;
        EnemySpawnerref = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().gameObject;
    }

    void Update()
    {
        TimeAlive += Time.deltaTime;
        if (TimeAlive >= 1f)
        {
            BulletPoolref.GetComponent<PoolScript>().TurnOffObjects(gameObject);
            TimeAlive = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject TempGO = collision.gameObject;

        if (TempGO.CompareTag("Enemy"))
        {
            Destroy(TempGO);
            GameManager.instance.IncreaseScore();
            EnemySpawnerref.GetComponent<EnemySpawner>().SpawnAnEnemy();
            BulletPoolref.GetComponent<PoolScript>().TurnOffObjects(gameObject);
            TimeAlive = 0;
        }
    }
}
