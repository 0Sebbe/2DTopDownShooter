using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public GameObject hitEffect;
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHp enemyHp = GetComponent<EnemyHp>();
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHp>().TakeDamage(damage);
        }
        BomberEnemy bomberEnemyHp = GetComponent<BomberEnemy>();
        if (other.CompareTag("BomberEnemy"))
        {
            other.GetComponent<BomberEnemy>().TakeDamage(damage);
        }
        if (other.CompareTag("GhostEnemy"))
        {
            other.GetComponent<GhostEnemy>().TakeDamage(damage);
        }
    }
}
