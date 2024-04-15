using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuroLightning : AbstractSkill
{
    [SerializeField] GameObject lightning;
    [SerializeField] int countLightningInAttack;

    protected override void Effect(float damage, float modSize, float modDuration, AbstractEntity[] enemiesInRangeAttack)
    {
        for (int i = 0; i < countLightningInAttack; i++)
        {
            var bullet = Instantiate(lightning, transform.position, lightning.transform.rotation).GetComponent<LightningPrefab>();
            bullet.damage = damage;
            bullet.modSize = modSize;
            bullet.distance = rangeAttack.radius;

            bullet.transform.rotation = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
        }
    }

    protected override void EffectOnNewLvl()
    {
        switch (Lvl)
        {
            case 2:
                countLightningInAttack += 2;
                break;
            case 3:
                countLightningInAttack += 2;
                break;
            case 4:
                modDamage += 0.2f;
                break;
            case 5:
                modSize *= 2;
                break;
            case 6:
                cooldown *= 0.5f;
                break;
            case 7:
                modDamage += 0.2f;
                break;
        }
    }
}
