using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float TimeReset = 5f;
    public Vector3 Force;
    public float side = 1;

    public int damage = 1;

    void Update()
    {
        transform.Translate(Force * Time.deltaTime * side);
    }

    public void Awake()
    {
        Destroy(gameObject, TimeReset);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.Damage(damage);
            Destroy(gameObject);
        }
        

    }
}
