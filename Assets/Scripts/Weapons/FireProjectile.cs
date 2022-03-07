using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject Projectile;
    public bool IsAutomatic;
    public float FiringCooldown;
    public int ClicksToFire;
    public float CoolingPerSecond;
    public float OverheatPerShot;


    private GameObject Crosshair;
    private GameObject CannonHolder;
    private GameObject FiringPoint;
    private float currentFiringCooldown;
    private int currentClicksToFire;

    private float currentOverheat;

    public GameObject FiringSoundEffectPrefab;
    public GameObject OverheatBreakSoundEffectPrefab;
    public GameObject MultiClickChargeSoundEffectPrefab;

    void Awake()
    {
        Crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        CannonHolder = GameObject.FindGameObjectWithTag("Cannon Holder");
        FiringPoint = GameObject.FindGameObjectWithTag("PlayerFiringPoint");
        currentFiringCooldown = 0;
        currentClicksToFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFiringCooldown > 0)
        {
            currentFiringCooldown -= Time.deltaTime;
        }

        if (currentOverheat > 0)
            currentOverheat -= CoolingPerSecond * Time.deltaTime;

        if (currentOverheat >= 100)
        {
            if (OverheatBreakSoundEffectPrefab != null)
                Instantiate(OverheatBreakSoundEffectPrefab);

            Destroy(gameObject);
        }
            
    }

    public void Fire(bool hold)
    {
        Vector2 difference = Crosshair.transform.position - CannonHolder.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

        if (IsAutomatic == true)
        {
            if (currentFiringCooldown <= 0)
            {
                fireBullet(direction, rotationZ);
                currentFiringCooldown = FiringCooldown;
                
                heatUp();
            }
        }

        else if (IsAutomatic == false && hold == false)
        {
            if (currentClicksToFire < ClicksToFire - 1)
            {
                currentClicksToFire++;

                if (MultiClickChargeSoundEffectPrefab != null)
                    Instantiate(MultiClickChargeSoundEffectPrefab);
            }

            else
            {
                fireBullet(direction, rotationZ);
                currentClicksToFire = 0;

                heatUp();
            }
        }
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject projectile = Instantiate(Projectile) as GameObject;
        projectile.transform.position = FiringPoint.transform.position;
        projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (FiringSoundEffectPrefab != null)
            Instantiate(FiringSoundEffectPrefab);
    }

    void heatUp()
    {
        currentOverheat += OverheatPerShot;
    }

    public float getCurrentOverheat()
    {
        return currentOverheat;
    }
}
