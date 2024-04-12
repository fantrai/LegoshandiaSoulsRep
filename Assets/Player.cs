using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractEntity
{
    [SerializeField] Joystick joystick;

    override protected void Movement()
    {
        transform.Translate(joystick.Direction * MovementSpeed);
    }
}
