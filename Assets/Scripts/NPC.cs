using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public GameObject dialogObject;
    public int state = 0;
    public Player player;
    public int deathRepImp;
    public int deathRepSkele;


    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (state == NPCstates.Idle)
        {
            Idle();
        }
        else if (state == NPCstates.Aggresive)
        {
            float playerY = player.transform.position.y;
            float playerX = player.transform.position.x;
            if (playerX - 1.5 > transform.position.x) MoveRight();
            else if (playerX + 1.5 < transform.position.x) MoveLeft();
            else Idle();
            if (playerY - 1 > transform.position.y) Jump();
        }
    }

    public override void TakeDamage(float d)
    {
        BecomeAggressive();
        base.TakeDamage(d);
    }

    protected override void Death()
    {
        Game.inst.characterDeaths.Add(gameObject.name);
        Game.inst.impRep += deathRepImp;
        Game.inst.skeleRep += deathRepSkele;
        base.Death();
    }

    private void BecomeAggressive()
    {
        dialogObject.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>();
        player.canMove = true; ;
        state = NPCstates.Aggresive;
    }

    public static class NPCstates
    {
        public static int Idle = 0;
        public static int Aggresive = 1;
    }
    public static class NPCtype
    {
        public static int Imp = 0;
        public static int Skeleton = 1;
    }
}
