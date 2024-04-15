using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence : AbstractSkill
{
    protected override void Effect(float damage, float modSize, float modDuration, AbstractEntity[] enemiesInRangeAttack)
    {
    }

    protected override void EffectOnNewLvl()
    {
        switch (Lvl)
        {
            case 1:
                player.BaseDamage *= 1.02f;
                break;
            case 2:
                player.BaseDamage /= 1.02f;
                player.BaseDamage *= 1.04f;
                break;
            case 3:
                player.BaseDamage /= 1.04f;
                player.BaseDamage *= 1.06f;
                break;
            case 4:
                player.BaseDamage /= 1.06f;
                player.BaseDamage *= 1.08f;
                break;
            case 5:
                player.BaseDamage /= 1.08f;
                player.BaseDamage *= 1.1f;
                break;
        }

    }
}
