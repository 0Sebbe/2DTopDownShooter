using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Icefollower : MonoBehaviour
{
    public AIPath aiPath;
    public GameObject iceBulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float nextFire = 0.0f;
    public float bulletForce = 15f;

    private Transform target;
    public float lineOfSite;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    void FixedUpdate()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(10f, 10f, 10f);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-10f, 10f, 10f);
        }

        float distanceFromTarget = Vector2.Distance(target.position, transform.position);
        if(distanceFromTarget < lineOfSite && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject iceBullet;
        iceBullet = Instantiate(iceBulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
