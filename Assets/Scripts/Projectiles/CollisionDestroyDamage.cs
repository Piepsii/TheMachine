using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroyDamage : MonoBehaviour
{
    public float Damage;

    public GameObject SoundEffectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (SoundEffectPrefab != null)
                Instantiate(SoundEffectPrefab);

            collision.gameObject.GetComponent<HealthDestroy>().health -= Damage;
            Destroy(gameObject);
        }
    }
}
