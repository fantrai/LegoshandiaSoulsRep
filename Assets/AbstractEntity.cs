using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

public abstract class AbstractEntity : MonoBehaviour
{
    [SerializeField] float hp;
    protected float maxHP;
    public float HP 
    {
        get { return hp; }
        set
        {
            hp = value; 
            if (hp > maxHP)
            {
                hp = maxHP;
            }
            if (hp <= 0)
            {
                Dead();
            } 
        }
    }

    [SerializeField] float baseDamage;
    public float BaseDamage
    {
        get { return baseDamage; }
        set
        {
            baseDamage = value;
            if (baseDamage <= 0)
            {
                baseDamage = 0;
            }
        }
    }

    [SerializeField] float attackSpeed;
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set
        {
            attackSpeed = value;
            if (attackSpeed <= 0)
            {
                attackSpeed = 0;
            }
        }
    }

    [SerializeField] float movementSpeed;
    public float MovementSpeed
    {
        get { return movementSpeed; }
        set
        {
            movementSpeed = value;
            if (movementSpeed <= 0)
            {
                movementSpeed = 0;
            }
        }
    }

    protected virtual void Start()
    {
        maxHP = hp;
    }

    protected virtual void FixedUpdate()
    {
        Movement();
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    protected abstract void Movement();

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out AbstractEntity ent))
        {
            ent.TakeDamage(baseDamage * attackSpeed * Time.fixedDeltaTime);
        }
    }
}
