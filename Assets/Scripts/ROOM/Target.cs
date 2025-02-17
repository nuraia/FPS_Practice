using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50;
    public void TakeDamage(float amount)
    {
        if(health <= 0)
        {
            Die();
        }
        health -= amount;
    }

    // Update is called once per frame
    public void Die()
    {
        Destroy(gameObject);
    }
    
}
