using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float reload;

    protected float lastStepTime = 0;
    protected float lastShootTime = 0;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        canMove = true;
        groundDistance = 1.5f;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        else animate.SetBool("Shooting", false);
    }

    private void Shoot()
    {
        if (Time.time > lastShootTime + reload)
        {
            lastShootTime = Time.time;
            animate.SetBool("Shooting", true);
            Game.inst.SoundShoot();
        }
        
    }

    void FixedUpdate()
    {
        PlayerMove();
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
}
