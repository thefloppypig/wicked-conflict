using System;
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
        hb = GameObject.Find("HUD").GetComponentInParent<HealthBar>();
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

        //remove dead npcs
        if (cl == "City District")
        {
            if (g.characterDeaths.Contains("Box1")) GameObject.Find("Box1").SetActive(false);
            if (g.characterDeaths.Contains("Box2"))
            {
                GameObject.Find("Box2").SetActive(false);
            }
            if (g.characterDeaths.Contains("Skeleton1")) GameObject.Find("Skeleton1").SetActive(false);
            if (g.characterDeaths.Contains("Imp1")) GameObject.Find("Imp1").SetActive(false);
        }
        if (cl == "Jeff's Home")
        {
            if (g.characterDeaths.Contains("Chicken")) GameObject.Find("Chicken").SetActive(false);
            if (g.characterDeaths.Contains("Wood1")) GameObject.Find("Wood1").SetActive(false);
            if (g.characterDeaths.Contains("Wood2")) GameObject.Find("Wood2").SetActive(false);
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
        hb.UpdateBar(d / 10);
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
}
