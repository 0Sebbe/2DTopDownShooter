using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 4;
    public int curHp;

    public int numberOffFlashes;
    public SpriteRenderer spriteRend;
    public float iFramesDur;

    public HealtBar healtbar;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 11, false);
        curHp = maxHp;
        healtbar.SetMaxHealth(maxHp);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            curHp -= 1;
            healtbar.SetHealth(curHp);
            StartCoroutine(Ivunerability());
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            curHp -= 1;
            healtbar.SetHealth(curHp);
            StartCoroutine(Ivunerability());
        }
        if (other.gameObject.CompareTag("BomberEnemy"))
        {
            curHp -= 2;
            healtbar.SetHealth(curHp);
            StartCoroutine(Ivunerability());
        }
        if (curHp < 1)
        {
            SceneManager.LoadScene(3);
        }
        if (other.gameObject.CompareTag("HealthPickup"))
        {
            if(curHp < 4)
            {
                curHp += 1;
            }
            healtbar.SetHealth(curHp);
        }
    }

    private IEnumerator Ivunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0);
            yield return new WaitForSeconds(iFramesDur / (numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDur / (numberOffFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
