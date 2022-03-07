using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float waveInterval = 0.5f;
    [SerializeField] private List<BoxCollider2D> spawnAreas;
    [SerializeField] private GameObject nextWaveButton;
    private Transform enemyPoolTransform;
    private Transform waveSourceTransform;
    private Transform currentWaveTransform;
    private float nextActionTime;
    private float gameTime;

    [Header("Procedural Generation")]
    [SerializeField] private GameObject wavePrefab;
    [SerializeField] private List<GameObject> ripplePool;
    private List<GameObject> ripplesToSpawn;
    private int instantiateIndex = 0;

    [Header("Tutorial")]
    [SerializeField] private GameObject tutorialPanel;
    public static int currentWaveIndex;
    public static bool tutorialIsActive = true;

    public bool isBetweenWave;

    void Start()
    {
        gameTime = 0f;
        isBetweenWave = false;

        if (tutorialIsActive) 
        { 
            tutorialPanel.SetActive(true);
            currentWaveIndex = 0;
        }
        else
        {
            currentWaveIndex = 1;
        }

        enemyPoolTransform = GameObject.FindWithTag("EnemyPool").transform;
        waveSourceTransform = GameObject.FindWithTag("WaveSource").transform;
        currentWaveTransform = waveSourceTransform.GetChild(0);
        nextActionTime = 0.0f;

        foreach (Transform child in waveSourceTransform)
            DeactivateChildren(child.gameObject);
    }


    void Update()
    {
        if(!tutorialIsActive)
        {
            gameTime += Time.deltaTime;

            if (GetWaveAt(currentWaveIndex) != null)
            {
                currentWaveTransform = GetWaveAt(currentWaveIndex).transform;
            }
            else
            {
                currentWaveTransform = null;
            }

            SpawnWave();


            if (CurrentWaveIsDone())
            {
                isBetweenWave = true;
            }
        }
    }

    void SpawnWave()
    {
        if (currentWaveTransform == null)
        {
            currentWaveTransform = CreateProceduralWave(currentWaveIndex);
        }

        if (gameTime > nextActionTime && currentWaveTransform.childCount > 0)
        {
            float rippleInterval = currentWaveTransform.GetChild(0).GetComponent<RippleProperties>().GetTimeUntilNextRipple();
            if (rippleInterval > 0)
            {
                nextActionTime += rippleInterval;
            }
            else
            {
                nextActionTime += waveInterval;
            }

            SpawnRipple(currentWaveTransform);
        }
    }

    void SpawnRipple(Transform wave)
    {
        if (wave.childCount <= 0)
        {
            return;
        }

        Transform ripple = wave.GetChild(0);
        ripple.gameObject.SetActive(true);
        ripple.SetParent(enemyPoolTransform);
        BoxCollider2D spawnZone;

        int direction = ripple.gameObject.GetComponent<RippleProperties>().GetDirection();
        switch (direction)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                spawnZone = spawnAreas[direction];
                break;
            case 4: // RANDOM
                spawnZone = spawnAreas[Random.Range(0, 4)];
                break;
            case 5: // EAST_WEST
                spawnZone = spawnAreas[Random.value >= 0.5f ? 1 : 3];
                break;
            case 6: // NORTH_SOUTH
                spawnZone = spawnAreas[Random.value >= 0.5f ? 0 : 2];
                break;
            default:
                spawnZone = spawnAreas[Random.Range(0, 4)];
                break;
        }

        Vector3 spawnZonePos = spawnZone.transform.position;

        foreach (Transform child in ripple)
        {
            float randomPosX = Random.Range(spawnZonePos.x - spawnZone.size.x / 2, spawnZonePos.x + spawnZone.size.x / 2);
            float randomPosY = Random.Range(spawnZonePos.y - spawnZone.size.y / 2, spawnZonePos.y + spawnZone.size.y / 2);
            Vector3 newPos = new Vector3(randomPosX, randomPosY, 0.0f);
            child.position = newPos;
        }
    }

    private bool CurrentWaveIsDone()
    {
        return enemyPoolTransform.childCount == 0 && currentWaveTransform.childCount == 0;
    }

    private void DeactivateChildren(GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(false);
            }
        }
    }


    private Transform CreateProceduralWave(int index)
    {
        IEnumerator instantiateWave;

        int difficultyPoints = index * index * 10 + 10;
        Transform waveToSpawn = Instantiate(wavePrefab, waveSourceTransform).transform;
        waveToSpawn.GetComponent<Wave>().waveIndex = index;
        ripplesToSpawn = new List<GameObject>();

        while(difficultyPoints > 0)
        {
            GameObject ripple = ripplePool[Random.Range(0, ripplePool.Count)];
            ripple.SetActive(false);
            int rippleDifficulty = ripple.GetComponent<RippleProperties>().difficultyValue;
            if (rippleDifficulty == 0)
                rippleDifficulty = 10;
            int counter = 0;
            while (difficultyPoints - rippleDifficulty < -5)
            {
                if (counter >= ripplePool.Count)
                    break;
                ripple = ripplePool[counter];
                counter++;
                rippleDifficulty = ripple.GetComponent<RippleProperties>().difficultyValue;
                if (rippleDifficulty == 0)
                    rippleDifficulty = 10;
            }
            difficultyPoints -= rippleDifficulty;
            ripplesToSpawn.Add(ripple);
        }

        instantiateIndex = 0;
        instantiateWave = InstantiateWithDelay(ripplesToSpawn, waveToSpawn, 0.1f);
        StartCoroutine(instantiateWave);

        return waveToSpawn;
    }

    IEnumerator InstantiateWithDelay(List<GameObject> list, Transform parent, float delay)
    {
       while(instantiateIndex < list.Count)
        {
            Instantiate(list[instantiateIndex], parent);
            instantiateIndex++;
            yield return new WaitForSeconds(delay);
        }
    }

    public void NextWave()
    {
        currentWaveIndex++;
        gameTime = 0f;
        nextActionTime = 0f;
        isBetweenWave = false;
    }


    GameObject GetWaveAt(int index)
    {
        for(int i = 0; i < waveSourceTransform.childCount; i++)
        {
            Wave currentChild = waveSourceTransform.GetChild(i).GetComponent<Wave>();
            if (currentChild.waveIndex == index)
                return currentChild.gameObject;
        }
        return null;
    }

    public int GetWaveIndex()
    {
        return currentWaveIndex;
    }

    public void SetTutorialIsActive(bool value)
    {
        tutorialIsActive = value;
    }
    public void SetCurrentWaveIndex(int value)
    {
        currentWaveIndex = value;
    }
}
