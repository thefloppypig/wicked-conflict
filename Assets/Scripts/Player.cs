using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 6;
    public float jumpForce = 5;

    private Rigidbody2D body;
    private Animator animate;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Jump();
        }
        if (Input.GetKey("space"))
        {
            Shoot();
        }
        else animate.SetBool("Shooting", false);
    }

    private void Shoot()
    {
        animate.SetBool("Shooting", true);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
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

    private void Idle()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }

    private void MoveRight()
    {
        body.velocity = new Vector2(moveSpeed,body.velocity.y);
    }

    private void MoveLeft()
    {
        body.velocity = new Vector2(-moveSpeed, body.velocity.y);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }
}
