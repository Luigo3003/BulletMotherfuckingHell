using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform OriginTransform;
    public Transform DestinationTransform;
    public float Speed = 0;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, DestinationTransform.position, Speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            transform.position = OriginTransform.position;
        }
    }
}
