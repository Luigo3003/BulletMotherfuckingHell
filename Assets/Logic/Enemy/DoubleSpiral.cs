using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpiral : MonoBehaviour
{
    private float angle = 0f;

    private Vector2 bulletMoveDirection;

    [SerializeField] GameObject EnemyBulletPoolref;
    // Start is called before the first frame update

    private void Awake()
    {
        EnemyBulletPoolref = GameObject.Find("BulletPoolEnemy").GetComponent<PoolScript>().gameObject;
    }


    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.2f);
    }

 
    private void Fire()
    {
        for (int i = 0; i <= 1 ; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180);

            Vector3 bulMovVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMovVector - transform.position).normalized;

            GameObject bul = EnemyBulletPoolref.GetComponent<PoolScript>().RequestObject();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<EnemyBulletLogic>().SetMoveDirection(bulDir);
        }

        angle += 10f;

        if (angle >= 360)
        {
            angle = 0f;
        }


    }
}
