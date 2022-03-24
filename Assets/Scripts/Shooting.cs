using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject boostBulletPrefab;
    bool dmgBoost = false;
    public float boostTimerStart = 7f;
    public float boostTimer;

    public float fireRate = 0.4f;
    public float nextFire = 0.0f;

    public float bulletForce = 20f;

    void Start()
    {
        boostTimer = boostTimerStart;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject boostBullet;
        GameObject bullet;
        if (dmgBoost == true)
        {
            boostBullet = Instantiate(boostBulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rbBoost = boostBullet.GetComponent<Rigidbody2D>();
            rbBoost.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        else if(dmgBoost == false)
        {
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void DamageIncrease()
    {
        dmgBoost = true;
        StartCoroutine(dmgBoostTimer());
        
    }
    private IEnumerator dmgBoostTimer()
    {
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(4);
            dmgBoost = false;
        }
    }
}
