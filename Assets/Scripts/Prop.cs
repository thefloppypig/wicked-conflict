using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Damagable
{
    protected bool isAlive = true;
    public bool tracked = false;
    protected override void Death()
    {
        if (!isAlive) return;
        if (tracked) Game.inst.characterDeaths.Add(gameObject.name);
        isAlive = false;
        base.Death();
    }
}
