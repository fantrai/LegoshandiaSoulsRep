using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractEntity
{
    [SerializeField] Joystick joystick;
    [SerializeField] float hpRegenerationPerSecond = 0;
    [SerializeField] float critChance = 0;
    [SerializeField] float modCriticalDamage = 2;
    [SerializeField] float chanceEvasion = 0;
    [SerializeField] float modMagicSize = 1;
    [SerializeField] float modSpellDuration = 1;
    [SerializeField] float modAddMana = 1;
    [SerializeField] float modMagicCooldown = 1;
    bool isLive = true;

    public float ModMagicSize { get => modMagicSize; }
    public float Damage 
    { 
        get 
        {
            if (Random.Range(0, 100) <= critChance)
            {
                return BaseDamage * modCriticalDamage;
            }
            else
            {
                return BaseDamage;
            }
        } 
    }
    public float ModSpellDuration { get => modSpellDuration; }
    public float ModMagicCooldown { get => modMagicCooldown; }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Regeneration());
    }

    public override void TakeDamage(float damage)
    {
        if (Random.Range(0, 100) <= chanceEvasion)
        {
            return;
        }
        else
        {
            base.TakeDamage(damage);
        }
    }

    override protected void Movement()
    {
        transform.Translate(joystick.Direction * MovementSpeed);
    }

    IEnumerator Regeneration()
    {
        do
        {
            yield return new WaitForSeconds(1);
            HP += hpRegenerationPerSecond;
        } while (isLive);
    }
}
