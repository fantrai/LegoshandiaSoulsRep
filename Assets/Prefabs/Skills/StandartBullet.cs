using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : MonoBehaviour
{
    public Vector2 moveVector;
    public float moveSpeed;
    public float modSize;
    public float damage;
    public float distance;
    public int piercing;

    private void Start()
    {
        transform.localScale *= modSize;
    }

    private void FixedUpdate()
    {
        distance -= moveSpeed;
        transform.Translate(moveVector.normalized * moveSpeed);
        if (distance <= 0) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
            piercing--;
            if (piercing <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
