using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroySpawn : MonoBehaviour
{
    public float Damage;
    public GameObject Spawn;

    public GameObject SoundEffectPrefab;

    private bool hasCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !hasCollided)
        {
            hasCollided = true;

            if (SoundEffectPrefab != null)
                Instantiate(SoundEffectPrefab);

            collision.gameObject.GetComponent<HealthDestroy>().health -= Damage;
            Instantiate(Spawn, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
    }
}
