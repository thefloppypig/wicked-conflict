using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float reload;
    public float bulletSpeed = 14;

    protected float lastStepTime = 0;
    protected float lastShootTime = 0;
    protected Vector3 offsetL = new Vector3(0.6f, -.20f,0);
    protected Vector3 offsetR = new Vector3(-0.6f, -.20f,0);
    public GameObject playerBulletPrefab;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        canMove = true;
        groundDistance = 1.5f;
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

    void FixedUpdate()
    {
        if (canMove) PlayerMove();
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
            animate.SetBool("Running", false);

        }
        else if (right)
        {
            MoveLeft();
            animate.SetBool("Running", true);
            sprite.flipX = true;
        }
        else if (left)
        {
            MoveRight();
            animate.SetBool("Running", true);
            sprite.flipX = false;
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
