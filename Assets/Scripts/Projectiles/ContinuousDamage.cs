using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDamage : MonoBehaviour
{
    public float Damage;

    public GameObject SoundEffectPrefab;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (SoundEffectPrefab != null)
                Instantiate(SoundEffectPrefab);

            collision.gameObject.GetComponent<HealthDestroy>().health -= Damage;
        }
    }
}
