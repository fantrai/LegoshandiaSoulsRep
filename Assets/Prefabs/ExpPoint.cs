using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{
    public float addExp;
    [SerializeField] float speed;
    [SerializeField] float destroyDistance;
    [SerializeField] Collider2D expCollider;

    public void FlyingToPerson(GameObject player)
    {
        expCollider.enabled = false;
        StartCoroutine(Flying(player));
    }

    IEnumerator Flying(GameObject player)
    {
        do
        {
            transform.Translate((player.transform.position - transform.position).normalized * speed);
            yield return new WaitForFixedUpdate();
        } while (Vector2.Distance(transform.position, player.transform.position) > destroyDistance);
        Destroy(gameObject);
    }
}
