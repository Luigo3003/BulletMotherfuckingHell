using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour
{
    [SerializeField] private GameObject BulletPoolref;

    private float TimeAlive = 0;

    private void Awake()
    {
       BulletPoolref = GameObject.Find("BulletPool").GetComponent<PoolScript>().gameObject;
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
}
