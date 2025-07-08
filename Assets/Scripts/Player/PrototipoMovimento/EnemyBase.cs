using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public HealthBase healthBase;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill += OnEnemyKill;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
        }
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);            
    }
}
