using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBuild : MonoBehaviour
{
    private ManageScrap scrapScript;

    [SerializeField]
    private KeyCode BuildButton;

    [SerializeField]
    private int ScrapNeededToBuild = 0;

    [SerializeField]
    private List<GameObject> Weapons;

    private int index;

    public GameObject SoundEffectPrefab;

    void Start()
    {
        scrapScript = GameObject.FindGameObjectWithTag("ScrapCounter").GetComponent<ManageScrap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(BuildButton))
        {
            if (scrapScript.amount >= ScrapNeededToBuild)
            {
                if (transform.childCount < 4)
                {
                    Debug.Log("Not enough slots in the Weapon Manager");
                }

                else if (transform.GetChild(0).childCount == 0)
                {
                    scrapScript.amount -= ScrapNeededToBuild;
                    CreateWeapon(0);
                }

                else if (transform.GetChild(1).childCount == 0)
                {
                    scrapScript.amount -= ScrapNeededToBuild;
                    CreateWeapon(1);
                }

                else if (transform.GetChild(2).childCount == 0)
                {
                    scrapScript.amount -= ScrapNeededToBuild;
                    CreateWeapon(2);
                }

                else if (transform.GetChild(3).childCount == 0)
                {
                    scrapScript.amount -= ScrapNeededToBuild;
                    CreateWeapon(3);
                }
            }
        }
    }

    void CreateWeapon(int slotId)
    {
        if (Weapons[index] != null)
        {
            GameObject newWeapon = Instantiate(Weapons[index]) as GameObject;

            newWeapon.transform.SetParent(transform.GetChild(slotId), false);

            index++;

            scrapScript.updateScrap();

            if (SoundEffectPrefab != null)
                Instantiate(SoundEffectPrefab);
        }
    }
}
