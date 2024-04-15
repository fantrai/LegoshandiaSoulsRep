using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraOfLightEnergy : AbstractSkill
{
    [SerializeField] GameObject sprite;

    protected override void Effect(float damage, float modSize, float modDuration, AbstractEntity[] enemiesInRangeAttack)
    {
        sprite.transform.localScale = Vector3.one * modSize;
        for (int i = 0; i < enemiesInRangeAttack.Length; i++)
        {
            enemiesInRangeAttack[i].TakeDamage(damage);
        }
    }

    protected override void EffectOnNewLvl()
    {
        switch (Lvl)
        {
            case 2:
                modSize *= 2;
                break;
            case 3:
                modDamage += 0.3f;
                break;
            case 4:
                modSize *= 4;
                break;
            case 5:
                modDamage += 0.2f;
                break;
        }
    }
}
