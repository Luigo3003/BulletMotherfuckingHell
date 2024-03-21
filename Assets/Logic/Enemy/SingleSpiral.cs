using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpiral : MonoBehaviour
{
    private float angle = 0f;

    private Vector2 bulletMoveDirection;

    [SerializeField] GameObject EnemyBulletPoolref;
    private void Awake()
    {
        EnemyBulletPoolref = GameObject.Find("BulletPoolEnemy").GetComponent<PoolScript>().gameObject;
    }


    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
    {

            float bulDirX = transform.position.x + Mathf.Sin(((angle  * Mathf.PI) / 180));
            float bulDirY = transform.position.y + Mathf.Cos(((angle  * Mathf.PI) / 180));

            Vector3 bulMovVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMovVector - transform.position).normalized;

            GameObject bul = EnemyBulletPoolref.GetComponent<PoolScript>().RequestObject();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<EnemyBulletLogic>().SetMoveDirection(bulDir);

        angle += 10f;

        if (angle >= 360)
        {
            angle = 0f;
        }


    }
}
