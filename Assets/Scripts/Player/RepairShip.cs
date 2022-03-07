using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairShip : MonoBehaviour
{
    private ManageScrap scrapScript;
    private PlayerHealth health;

    [SerializeField]
    private KeyCode RepairButton;

    [SerializeField]
    private int ScrapNeededToRepair = 0;

    [SerializeField]
    private int HealthRepaired = 1000;

    [SerializeField]
    private float cooldownInSeconds = 0.5f;
    private float timeSinceLastRepair = float.MaxValue;

    public GameObject SoundEffectPrefab;

    void Start()
    {
        scrapScript = GameObject.FindGameObjectWithTag("ScrapCounter").GetComponent<ManageScrap>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastRepair += Time.deltaTime;

        if (Input.GetKeyDown(RepairButton))
        {
            if (scrapScript.amount >= ScrapNeededToRepair && timeSinceLastRepair > cooldownInSeconds)
            {
                if (health.CurrentHealth == health.MaxHealth)
                { }

                else if (health.CurrentHealth >= health.MaxHealth - HealthRepaired)
                {
                    health.CurrentHealth = health.MaxHealth;
                    scrapScript.amount -= ScrapNeededToRepair;
                    scrapScript.updateScrap();

                    if (SoundEffectPrefab != null)
                        Instantiate(SoundEffectPrefab);

                    timeSinceLastRepair = 0.0f;
                }

                else
                {
                    health.addHealth(HealthRepaired);
                    scrapScript.amount -= ScrapNeededToRepair;
                    scrapScript.updateScrap();

                    if (SoundEffectPrefab != null)
                        Instantiate(SoundEffectPrefab);

                    timeSinceLastRepair = 0.0f;
                }
            }
        }
    }

    public float GetCooldownPercentage()
    {
        return Mathf.Clamp(1.0f - timeSinceLastRepair / cooldownInSeconds + 0.0001f, 0.0f, 1.0f);
    }
}
