using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public int maxHp = 5;
    public int hp;
    

    public float flashDur;
    public int numberOffFlashes;
    public SpriteRenderer spriteRend;

    KillCounter killCounterScript;
    public AIPath aiPath;

    public GameObject[] pickupDrops;
    public int drops;


    void Start()
    {
        hp = maxHp;
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
    }

    public void Update()
    {

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(10f, 10f, 10f);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-10f, 10f, 10f);
        }
        KillCounter killCounter = GetComponent<KillCounter>();
        if (hp < 1)
        {
            Destroy(gameObject);
            killCounterScript.AddKill();
            int number = Random.Range(0, 20);
            if(number <= 5)
            {
                Instantiate(pickupDrops[Random.Range(0, drops)], transform.position, Quaternion.identity);
            }
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
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0);
            yield return new WaitForSeconds(flashDur / (numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(flashDur / (numberOffFlashes * 2));
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
