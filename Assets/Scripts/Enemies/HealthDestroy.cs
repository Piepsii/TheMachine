using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDestroy : MonoBehaviour
{
    public float health;
    [Range(0.0f, 1.0f)]
    public float dropChance;
    public GameObject scrap;

    private Transform scrapContainer;
    float previousHealth;
    private SpriteRenderer spriteRenderer;
    private Color color;
    private Color hitColor;
    private bool beingHit;
    private int frameCounter;
    private int framesBeingHit;

    public GameObject DyingSoundEffectPrefab;

    void Start()
    {
        scrapContainer = GameObject.FindGameObjectWithTag("ScrapContainer").transform;
        previousHealth = health;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        color = spriteRenderer.color;
        hitColor = spriteRenderer.color;
        hitColor.r -= 10;
        hitColor.g -= 10;
        hitColor.b -= 10;
        frameCounter = 0;
        framesBeingHit = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (DyingSoundEffectPrefab != null)
            {

                if (GameObject.FindGameObjectsWithTag("DyingSFX").Length < 3)
                {
                    Instantiate(DyingSoundEffectPrefab);
                }
            }

            if (Random.Range(0.0f, 1.0f) <= dropChance)
                Instantiate(scrap, transform.position, transform.rotation, scrapContainer);
            Destroy(gameObject);
        }

        DrawBeingHitColor();
    }

    private void DrawBeingHitColor()
    {
        if (previousHealth != health)
        {
            spriteRenderer.color = hitColor;
            beingHit = true;
        }

        if (beingHit)
        {
            frameCounter++;
            if (frameCounter > framesBeingHit)
            {
                spriteRenderer.color = color;
                frameCounter = 0;
                beingHit = false;
            }
        }

        previousHealth = health;
    }
}
