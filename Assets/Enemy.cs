using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AbstractEntity
{
    public static GameObject tarfet;

    protected override void Movement()
    {
        Vector2 vectorMove = (tarfet.transform.position - transform.position).normalized;
        transform.Translate(vectorMove * MovementSpeed);
    }
}
