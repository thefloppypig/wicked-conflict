﻿using System;
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

    protected float lastAttack;
    protected float attackCooldown = 0.3f;
    protected bool alive = true;

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
            if (playerX - 1.2 > transform.position.x) MoveRight();
            else if (playerX + 1.2 < transform.position.x) MoveLeft();
            else Idle();
            if (playerY - 1 > transform.position.y) Jump();
            Attack();
        }
    }

    private void Attack()
    {
        if (player.health <= 0) state = NPCstates.Idle;
        if (Time.time > lastAttack + attackCooldown && player.canMove)
        {
            Collider2D[] cs = Physics2D.OverlapCircleAll(transform.position, 1.3f);
            Collider2D cp = player.GetComponent<Collider2D>();
            foreach (Collider2D c in cs)
            {
                if (c == cp)
                {
                    player.TakeDamage(1);
                    player.TakeKnockback(transform.position,2);
                    Game.inst.SoundHurt();
                    lastAttack = Time.time + attackCooldown;
                    break;
                }
            }
        }
    }

    public override void TakeDamage(float d)
    {
        BecomeAggressive();
        base.TakeDamage(d);
    }

    protected override void Death()
    {
        if (!alive) return;
        alive = false;
        Game.inst.characterDeaths.Add(gameObject.name);
        Game.inst.impRep += deathRepImp;
        Game.inst.skeleRep += deathRepSkele;
        Game.inst.UpdateRep();
        base.Death();
    }

    private void BecomeAggressive()
    {
        if (state == NPCstates.Aggresive) return;
        lastAttack = Time.time + attackCooldown;
        dialogObject.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>();
        player.canMove = true; ;
        state = NPCstates.Aggresive;
    }

    public static class NPCstates
    {
        public static int Idle = 0;
        public static int Aggresive = 1;
        public static int Scripted = 2;
    }
    public static class NPCtype
    {
        public static int Imp = 0;
        public static int Skeleton = 1;
    }

}