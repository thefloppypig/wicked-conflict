using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1;
    private void OnCollisionEnter(Collision col)
    {
        Character charac = col.gameObject.GetComponent<Character>();
        if (charac != null)
        {
            charac.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
