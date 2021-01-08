using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1;
    public float kbstrength = 1;
    Character user;

    public void Init(float speed,Character u)
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.velocity = speed * Vector2.right;
        user = u;
        Destroy(gameObject,5);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Damagable obj = col.gameObject.GetComponent<Damagable>();
        if (obj != null && user!= obj)
        {
            obj.TakeDamage(damage);
            obj.TakeKnockback(transform.position,kbstrength);
        }
        Destroy(gameObject);
    }
}
