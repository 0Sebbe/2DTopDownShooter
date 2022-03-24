using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float shootingDistance;
    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject bullet;
    public Transform firePoint;
    private Rigidbody2D ribo;

    public float maxHp = 6;
    public float hp;

    public SpriteRenderer spriteRend;
    KillCounter killCounterScript;

    void Start()
    {
        hp = maxHp;
        timeBtwShots = startTimeBtwShots;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ribo = GetComponent<Rigidbody2D>();
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
        spriteRend.color = new Color(1f, 1f, 1f, 0.80f);
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < shootingDistance)
        {
            Shoot();
        }
        KillCounter killCounter = GetComponent<KillCounter>();

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(transform.position.x < player.position.x)
        {
            transform.localScale = new Vector2(10, 10);
        }
        else
        {
            transform.localScale = new Vector2(-10, 10);
        }
        if (hp < 1)
        {
            Destroy(gameObject);
            killCounterScript.AddKill();
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
            spriteRend.color = new Color(1f, 0, 0f, 0.80f);
            yield return new WaitForSeconds(0.3f);
            spriteRend.color = new Color(1f, 1f, 1f, 0.80f);
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
    void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * speed, ForceMode2D.Impulse);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
