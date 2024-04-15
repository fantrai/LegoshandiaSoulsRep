using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningPrefab : MonoBehaviour
{
    public float modSize;
    public float damage;
    public float distance;

    private void Start()
    {
        transform.localScale *= modSize;
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
        }
    }
}
