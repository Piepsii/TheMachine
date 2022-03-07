using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{

    private Button nextButton;
    private int indexAsChild;
    private GameObject nextDialogue;
    private GameObject nextWaveButton;

    // Start is called before the first frame update
    void Start()
    {
        nextButton = GetComponentInChildren<Button>();
        nextButton.onClick.AddListener(NextDialogueOrWave);
        indexAsChild = transform.GetSiblingIndex();
        if (indexAsChild + 1 < transform.parent.childCount)
            nextDialogue = transform.parent.GetChild(indexAsChild + 1).gameObject;
        else
            nextDialogue = null;
    }

    void NextDialogueOrWave()
    {
        if(nextWaveButton == null)
            nextWaveButton = GameObject.FindGameObjectWithTag("NextWaveButton");

        if(nextDialogue != null)
        {
            gameObject.SetActive(false);
            nextDialogue.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            nextWaveButton.transform.GetChild(0).gameObject.SetActive(true);
            nextWaveButton.GetComponent<Button>().enabled = true;
            nextWaveButton.GetComponent<Image>().enabled = true;
        }
    }
}
