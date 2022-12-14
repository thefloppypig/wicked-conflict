using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Damagable
{
    public float moveSpeed = 6;
    public float jumpForce = 5;
    [HideInInspector] public bool canMove = true;

    protected bool grounded = false;
    protected int jumpsRemaining = 0;
    protected float lastJumpTime = 0;
    protected float jumpDelay = 0.5f;
    const int maxJumps = 1;
    protected float groundDistance = 0.8f;

    protected Animator animate;
    [SerializeField]protected LayerMask collisionMask;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        animate = GetComponent<Animator>();
        groundDistance = 1.5f;
    }

    protected void Idle()
    {
        body.velocity = new Vector2(0, body.velocity.y);
        animate.SetBool("Running", false);
    }

    public void MoveRight()
    {
        body.velocity = new Vector2(moveSpeed, body.velocity.y);
        animate.SetBool("Running", true);
        sprite.flipX = false;
    }

    public void MoveLeft()
    {
        body.velocity = new Vector2(-moveSpeed, body.velocity.y);
        animate.SetBool("Running", true);
        sprite.flipX = true;
    }

    protected virtual void Jump()
    {
        if (jumpsRemaining > 0 && Time.time > lastJumpTime + jumpDelay)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpsRemaining--;
            lastJumpTime = Time.time;
        }
    }
    protected void IsGrounded()
    {
        grounded = Physics2D.Raycast(body.position, Vector2.down, groundDistance, collisionMask);
        Debug.DrawRay(body.position, Vector3.down * groundDistance, Color.green, 0);
        if (grounded)
        {
            animate.SetBool("Falling", false);
            jumpsRemaining = maxJumps;
        }
        else
        {
            animate.SetBool("Falling", true);
        }
    }

    

}
