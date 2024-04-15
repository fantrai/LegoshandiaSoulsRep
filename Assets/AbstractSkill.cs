using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractSkill : MonoBehaviour
{
    public static Action EndCast;

    public int MaxLvl { get => maxLvl; }
    public int Lvl { get => lvl; }
    [SerializeField] protected float modDamage = 1;
    [SerializeField] protected float addDamage = 0;
    [SerializeField] protected float modSize = 1;
    [SerializeField] protected float cooldown;
    [SerializeField] int maxLvl = 0;
    [SerializeField] string[] descriptionsOnLvls;
    [SerializeField] protected CircleCollider2D rangeAttack;
    [SerializeField] Image ico;
    protected List<AbstractEntity> enemiesInRangeAttack = new List<AbstractEntity>();
    float baseRangeAttack;
    int lvl = 0;
    Player player;

    private void Awake()
    {
        baseRangeAttack = rangeAttack.radius;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EndCast += StopAllCoroutines;
    }

    private void OnDisable()
    {
        EndCast -= StopAllCoroutines;
    }

    public void NewLvl()
    {
        lvl++;
        if (lvl != 1)
        {
            EffectOnNewLvl();
        }
    }

    protected abstract void EffectOnNewLvl();

    public void PrintPan(SkillPan pan)
    {
        pan.UpdatePan(ico, descriptionsOnLvls[lvl]);
    }

    public void StartCast(Player player)
    {
        gameObject.SetActive(true);
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
            Effect(player.Damage * modDamage + addDamage, player.ModMagicSize * modSize, player.ModSpellDuration, enemiesInRangeAttack.ToArray());
        } while (true);
    }

    abstract protected void Effect(float damage, float modSize, float modDuration, AbstractEntity[] enemiesInRangeAttack);
}