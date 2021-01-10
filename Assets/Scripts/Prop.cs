using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Damagable
{
    public bool tracked = false;
    protected override void Death()
    {
        if (tracked) Game.inst.characterDeaths.Add(gameObject.name);
        base.Death();
    }
}
