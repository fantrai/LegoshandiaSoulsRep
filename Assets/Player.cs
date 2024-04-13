using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractEntity
{
    [SerializeField] Joystick joystick;
    [SerializeField] float hpRegenerationPerSecond;
    bool isLive = true;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Regeneration());
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
