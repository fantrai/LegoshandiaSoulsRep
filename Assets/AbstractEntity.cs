using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

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

    [SerializeField] float touchAttackSpeed;
    public float AttackSpeed
    {
        get { return touchAttackSpeed; }
        set
        {
            touchAttackSpeed = value;
            if (touchAttackSpeed <= 0)
            {
                touchAttackSpeed = 0;
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

    List<AbstractEntity> touchEnemies = new List<AbstractEntity>();

    protected virtual void Start()
    {
        maxHP = hp;
        StartCoroutine(TouchDamager());
    }

    protected virtual void FixedUpdate()
    {
        Movement();
    }

    public virtual void TakeDamage(float damage)
    {
        HP -= damage;
    }

    protected abstract void Movement();

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out AbstractEntity ent))
        {
            touchEnemies.Add(ent);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out AbstractEntity ent))
        {
            if (touchEnemies.Contains(ent))
            {
                touchEnemies.Remove(ent);
            }
        }
    }

    IEnumerator TouchDamager()
    {
        do
        {
            for (int i = 0; i < touchEnemies.Count; i++)
            {
                if (touchEnemies[i] != null)
                {
                    touchEnemies[i].TakeDamage(BaseDamage);
                }
                else
                {
                    touchEnemies.Remove(touchEnemies[i]);
                }
            }
            yield return new WaitForSeconds(1 / touchAttackSpeed);
        } while (true);
    }
}
