using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
    public float health=0;
    protected Rigidbody2D body;
    protected SpriteRenderer sprite;

    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public virtual void TakeDamage(float d)
    {
        StartCoroutine(DamageFlash());
        health -= d;
        if (health <= 0)
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

    protected virtual void Death()
    {
        Destroy(gameObject,0.1f);
    }

    IEnumerator DamageFlash()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;

    }
}
