using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
    public float health;
    protected Rigidbody2D body;

    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }
    public void TakeDamage(float d)
    {
        health -= d;
        if (health < 0)
        {
            health = 0;
            Death();
        }
    }

    public void TakeKnockback(Vector3 source, float strength)
    {
        Vector3 direction = transform.position - source;
        body.AddForce((direction.normalized + Vector3.up / 5) * strength, ForceMode2D.Impulse);
    }

    protected void Death()
    {
        Destroy(gameObject);
    }
}
