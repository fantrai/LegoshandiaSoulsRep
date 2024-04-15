using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayOfLight : AbstractSkill
{
    [SerializeField] GameObject lightning;
    [SerializeField] int countLightningInAttack;

    protected override void Effect(float damage, float modSize, float modDuration, AbstractEntity[] enemiesInRangeAttack)
    {
        for (int i = 0; i < countLightningInAttack; i++)
        {
            var bullet = Instantiate(lightning, transform.position, transform.rotation).GetComponent<LightningPrefab>();
            bullet.damage = damage;
            bullet.modSize = modSize;
            bullet.distance = rangeAttack.radius;

            bullet.transform.Rotate(Vector3.forward * Random.Range(-30, 30));
        }
    }

    protected override void EffectOnNewLvl()
    {
        switch (Lvl)
        {
            case 2:
                countLightningInAttack += 1;
                break;
            case 3:
                modDamage += 0.3f;
                break;
            case 4:
                cooldown *= 0.8f;
                break;
            case 5:
                modDamage += 0.2f;
                break;
        }
    }
}
