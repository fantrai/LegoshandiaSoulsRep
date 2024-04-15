using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : AbstractEntity
{
    public static Action onNewLvl;

    public float Exp {
        get 
        {
            return exp;
        }
        private set
        {
            exp = value;
            if (exp >= expBeforeNextLvl)
            {
                Lvl++;
                exp -= expBeforeNextLvl;
                expBeforeNextLvl *= modExpOnNewLvl;
                expSlider.maxValue = expBeforeNextLvl;
                onNewLvl();
            }
            expSlider.value = exp;
        }
    }
    float exp;

    [SerializeField] GameObject playerObj;
    public int Lvl { get; private set; } = 1;
    [SerializeField] float expBeforeNextLvl;
    [SerializeField] float modExpOnNewLvl = 1;
    [SerializeField] Slider expSlider;
    public List<AbstractSkill> skills = new List<AbstractSkill>();
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

    protected override void Awake()
    {
        base.Start();
        expSlider.maxValue = expBeforeNextLvl;
        StartCoroutine(Regeneration());
        for (int i = 0; i < skills.Count; i++)
        {
            AddNewSkill(Instantiate(skills[i].gameObject));
        }
    }

    public void AddNewSkill(GameObject skill)
    {
        skill.transform.parent = playerObj.transform;
        skill.SetActive(true);
        if (skill.TryGetComponent(out AbstractSkill abstSkill))
        {
            abstSkill.StartCast(this);
        }
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
        playerObj.transform.Translate(joystick.Direction * MovementSpeed);
    }

    IEnumerator Regeneration()
    {
        do
        {
            yield return new WaitForSeconds(1);
            HP += hpRegenerationPerSecond;
        } while (isLive);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.TryGetComponent(out ExpPoint exp))
        {
            Exp += exp.addExp;
            exp.FlyingToPerson(gameObject);
        }
    }
}
