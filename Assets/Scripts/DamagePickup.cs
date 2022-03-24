using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Shooting dmgBoost = GetComponent<Shooting>();
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Shooting>().DamageIncrease();
        }
    }
}
