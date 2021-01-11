﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public float reload;
    public float bulletSpeed = 14;

    protected float lastStepTime = 0;
    protected float lastShootTime = 0;
    protected Vector3 offsetL = new Vector3(0.6f, -.20f,0);
    protected Vector3 offsetR = new Vector3(-0.6f, -.20f,0);
    public GameObject playerBulletPrefab;
    protected HealthBar hb;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        canMove = true;
        groundDistance = 1.8f;
        jumpDelay = 0.05f;
        SetPlayerLocation();
        hb = GameObject.Find("HUD").GetComponentInChildren<HealthBar>();
    }

    private void SetPlayerLocation()
    {
        Game g = Game.inst;
        string cl = g.currentLocation;
        string ll = g.lastLocation;
        //player location
        if (cl == "Jeff's Home" && ll == "City District")
        {
            transform.position = new Vector2(33f, -6.7f);
            GameObject.Find("Talk1Trigger").SetActive(false);
        }
        else if (cl == "City District" && ll == "Skeleton Bar")
        {
            transform.position = new Vector2(12.6528f, 0.35f);
        }
        else if (cl == "City District" && ll == "King's Quarters")
        {
            transform.position = new Vector2(27.61727f, 0.35f);
        }
        else if (cl == "City District" && ll == "Imp Hideout")
        {
            transform.position = new Vector2(42.34438f, 0.35f);
        }

        //remove dead npcs
        if (cl == "City District")
        {
            string[] inp = { "Box1", "Box2", "Skeleton1", "Skeleton2", "Skeleton3", "Imp1", "Imp2", "Imp3","Imp4" };
            foreach (string i in inp)
                if (g.characterDeaths.Contains(i)) GameObject.Find(i).SetActive(false);
        }
        if (cl == "Jeff's Home")
        {
            string[] inp = { "Chicken", "Wood1", "Wood2"};
            foreach (string i in inp)
                if (g.characterDeaths.Contains(i)) GameObject.Find(i).SetActive(false);
        }
        if (cl == "Imp Hideout")
        {
            string[] inp = { "Wood3", "Wood4"};
            foreach (string i in inp)
                if (g.characterDeaths.Contains(i)) GameObject.Find(i).SetActive(false);
        }
        if (cl == "Skeleton Bar")
        {
            string[] inp = { "Box11", "Skeleton11", "Skeleton12", "Imp11"};
            foreach (string i in inp)
                if (g.characterDeaths.Contains(i)) GameObject.Find(i).SetActive(false);
        }
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
        }
        if (Input.GetMouseButton(0) && canMove)
        {
            Shoot();
        }
        else animate.SetBool("Shooting", false);

    }

    protected void Shoot()
    {
        if (Time.time > lastShootTime + reload)
        {
            Bullet b;
            if (sprite.flipX == false)
            {
                b = Instantiate(playerBulletPrefab, transform.position+offsetL, transform.rotation).GetComponent<Bullet>();
                b.Init(bulletSpeed+body.velocity.x,this);
            }
            else
            {
                b = Instantiate(playerBulletPrefab, transform.position + offsetR, transform.rotation).GetComponent<Bullet>();
                b.Init(-bulletSpeed+body.velocity.x,this);
            }
            lastShootTime = Time.time;
            animate.SetBool("Shooting", true);
            Game.inst.SoundShoot();
        }
        
    }

    public override void TakeDamage(float d)
    {
        base.TakeDamage(d);
        if (hb!=null)
            hb.UpdateBar(health / 10);
    }

    void FixedUpdate()
    {
        if (canMove) PlayerMove();
        else Idle();
        IsGrounded();
    }

    private void PlayerMove()
    {
        bool left = Input.GetKey("d");
        bool right = Input.GetKey("a");
        if (left && right || !(left || right))
        {
            //stand still
            Idle();
        }
        else if (right)
        {
            MoveLeft();
            
        }
        else if (left)
        {
            MoveRight();
            
        }

    }
    protected new void Jump()
    {
        if (jumpsRemaining > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpsRemaining--;
            Game.inst.SoundJump();
        }
    }

    public void SetPlayerMove(bool move)
    {
        Idle();
        animate.SetBool("Running", false);
        animate.SetBool("Falling", false);
        animate.SetBool("Shooting", false);
        canMove = move;
        lastShootTime = Time.time + 1;
    }

    protected override void Death()
    {
        animate.SetTrigger("Death");
        Game.inst.PlayerDeath();
        SetPlayerMove(false);
    }
}
