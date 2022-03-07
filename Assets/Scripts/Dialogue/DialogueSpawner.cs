using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] dialogueSections;
    [SerializeField] private WaveSpawner waveSpawner;
    [SerializeField] private GameObject nextWaveButton;
    private GameObject dialogueSectionToSpawn;
    private int countOfSameDialogue;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        countOfSameDialogue = 0;
        once = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (waveSpawner.isBetweenWave)
        {
            if (!once)
            {
                once = true;
                SpawnDialogue();
            }
        }
        else
        {
            once = false;
        }
    }

    void SpawnDialogue()
    {
        if(WaveSpawner.currentWaveIndex == 0)
        {
            nextWaveButton.transform.GetChild(0).gameObject.SetActive(true);
            nextWaveButton.GetComponent<Button>().enabled = true;
            nextWaveButton.GetComponent<Image>().enabled = true;
            return;
        }

        countOfSameDialogue = 0;
        for(int i = 0; i < dialogueSections.Length; i++)
        {
            if(dialogueSections[i].GetComponent<DialogueSection>().playsAfterWave == WaveSpawner.currentWaveIndex)
            {
                dialogueSectionToSpawn = dialogueSections[i];
                countOfSameDialogue++;
            }
        }

        Debug.Assert(countOfSameDialogue <= 1, countOfSameDialogue.ToString() + " dialogues set to the same spawnAtWave value: " + WaveSpawner.currentWaveIndex.ToString());

        if (dialogueSectionToSpawn == null)
        {
            dialogueSectionToSpawn = dialogueSections[Random.Range(0, dialogueSections.Length)];
        }
        Instantiate(dialogueSectionToSpawn, transform);
        dialogueSectionToSpawn = dialogueSectionToSpawn.GetComponent<DialogueSection>().leadsTo;
    }
}
