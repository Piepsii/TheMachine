using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileDamage : MonoBehaviour
{
    public int Damage;

    public GameObject SoundEffectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (SoundEffectPrefab != null)
                Instantiate(SoundEffectPrefab);

            collision.gameObject.GetComponent<PlayerHealth>().reduceHealth(Damage);
            Destroy(gameObject);
        }
    }
}
