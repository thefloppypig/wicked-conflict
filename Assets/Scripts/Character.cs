using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Damagable
{
    public String state;
    public float moveSpeed = 6;
    public float jumpForce = 5;

    protected bool canMove = true;
    protected bool grounded = false;
    protected int jumpsRemaining = 0;
    const int maxJumps = 1;
    protected float groundDistance = 0.8f;

    protected Animator animate;
    protected SpriteRenderer sprite;
    [SerializeField]protected LayerMask collisionMask;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        animate = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        groundDistance = 1.5f;
    }

    protected void Idle()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }

    protected void MoveRight()
    {
        body.velocity = new Vector2(moveSpeed, body.velocity.y);
    }

    protected void MoveLeft()
    {
        body.velocity = new Vector2(-moveSpeed, body.velocity.y);
    }

    protected virtual void Jump()
    {
        if (jumpsRemaining > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpsRemaining--;
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
