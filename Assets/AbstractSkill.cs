using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSkill : MonoBehaviour
{
    public static Action EndCast;

    [SerializeField] float modDamage = 1;
    [SerializeField] float modSize = 1;
    [SerializeField] float cooldown;
    [SerializeField] CircleCollider2D rangeAttack;
    protected List<AbstractEntity> enemiesInRangeAttack = new List<AbstractEntity>();
    float baseRangeAttack;
    Player player;

    private void Start()
    {
        baseRangeAttack = rangeAttack.radius;
    }

    private void OnEnable()
    {
        EndCast += StopAllCoroutines;
    }

    private void OnDisable()
    {
        EndCast -= StopAllCoroutines;
    }

    public void StartCast(Player player)
    {
        this.player = player;
        StartCoroutine(Cast());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out AbstractEntity ent))
        {
            enemiesInRangeAttack.Add(ent);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out AbstractEntity ent))
        {
            if (enemiesInRangeAttack.Contains(ent))
            {
                enemiesInRangeAttack.Remove(ent);
            }
        }
    }

    IEnumerator Cast()
    {
        do
        {
            yield return new WaitForSeconds(cooldown * player.ModMagicCooldown);
            rangeAttack.radius = baseRangeAttack * modSize * player.ModMagicSize;
            Effect(player.Damage * modDamage, player.ModMagicSize * modSize, player.ModSpellDuration, enemiesInRangeAttack.ToArray());
        } while (true);
    }

    abstract protected void Effect(float damage, float modSize, float modDuration, AbstractEntity[] enemiesInRangeAttack);
}