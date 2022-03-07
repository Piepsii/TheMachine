using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterLifetime : MonoBehaviour
{

    public float lifetime;

    [SerializeField]
    private GameObject OnDestroySpawnPrefab;

    [SerializeField]
    private GameObject OnDestroySoundPrefab;

    private float currentLifetime;
    private bool hasSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        currentLifetime = lifetime;
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        if (currentLifetime > 0.05)
        {
            currentLifetime -= Time.deltaTime;
        }

        else if (!hasSpawned)
        {
            hasSpawned = true;

            if (OnDestroySpawnPrefab != null)
            {
                Instantiate(OnDestroySpawnPrefab, gameObject.transform.position, gameObject.transform.rotation);
            }

            if (OnDestroySoundPrefab != null)
            {
                Instantiate(OnDestroySoundPrefab);
            }
        }
    }
}
