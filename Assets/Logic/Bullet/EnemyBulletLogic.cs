using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    

    [SerializeField] GameObject EnemyBulletPoolref;
    [SerializeField] private float speed = 3f; 

    private Vector2 moveDirection;
    private float TimeAlive = 0;

    private void Awake()
    {
        EnemyBulletPoolref = GameObject.Find("BulletPoolEnemy").GetComponent<PoolScript>().gameObject;
    }

    void Update()
    {
        TimeAlive += Time.deltaTime;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (TimeAlive >= 5f)
        {
            EnemyBulletPoolref.GetComponent<PoolScript>().TurnOffObjects(gameObject);
            TimeAlive = 0;
        }
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject tempGO = collision.gameObject;

        if (tempGO.CompareTag("Player"))
        {
            tempGO.GetComponent<PlayerMov>().Dead();
            EnemyBulletPoolref.GetComponent<PoolScript>().TurnOffObjects(gameObject);
            TimeAlive = 0;
        }
    }
}
