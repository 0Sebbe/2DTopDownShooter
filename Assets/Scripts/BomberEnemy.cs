using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BomberEnemy : MonoBehaviour
{
    public int hp = 3;
    public AIPath aiPath;
    public SpriteRenderer spriteRend;
    public GameObject deathEffect;
    KillCounter killCounterScript;

    void Start()
    {
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
    }
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-10f, 10f, 10f);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(10f, 10f, 10f);
        }
        if(hp < 1)
        {
            Destroy(gameObject);
            killCounterScript.AddKill();
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            StartCoroutine(Flash());
        }
    }
    private IEnumerator Flash()
    {
        for (int i = 0; i < 1; i++)
        {
            spriteRend.color = new Color(1, 0, 0);
            yield return new WaitForSeconds(0.3f);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
