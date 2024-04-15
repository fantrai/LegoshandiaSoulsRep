using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBalls : AbstractSkill
{
    [SerializeField] GameObject lightBallPrefab;
    [SerializeField] int piercing = 0;
    [SerializeField] int countBallInAttack;
 
    protected override void Effect(float damage, float modSize, float modDuration, AbstractEntity[] enemiesInRangeAttack)
    {
        for (int i = 0; i < countBallInAttack && enemiesInRangeAttack.Length > 0; i++) 
        {
            var bullet = Instantiate(lightBallPrefab, transform.position, lightBallPrefab.transform.rotation).GetComponent<StandartBullet>();
            bullet.damage = damage;
            bullet.modSize = modSize;
            bullet.distance = rangeAttack.radius;
            bullet.piercing = piercing;
            bullet.moveVector = (enemiesInRangeAttack[Random.Range(0, enemiesInRangeAttack.Length)].transform.position - transform.position).normalized;
        }
    }

    protected override void EffectOnNewLvl()
    {
        switch (Lvl)
        {
            case 2:
                countBallInAttack += 2;
                break;
            case 3:
                countBallInAttack += 2;
                break;
            case 4:
                modDamage += 0.2f;
                break;
            case 5:
                modSize *= 2;
                break;
            case 6:
                countBallInAttack += 3;
                break;
            case 7:
                modDamage += 0.2f;
                break;
        }
    }
}
