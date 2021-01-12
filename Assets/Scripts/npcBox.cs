using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcBox : Prop
{
    public int repChangeImp;
    public int repChangeSkele;
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //nothing
    }

    protected override void Death()
    {
        Game.inst.impRep += repChangeImp;
        Game.inst.skeleRep += repChangeSkele;
        Game.inst.UpdateRep();
        base.Death();
    }
}
