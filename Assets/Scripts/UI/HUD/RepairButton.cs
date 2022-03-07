using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairButton : MonoBehaviour
{

    Image image;
    RepairShip repair;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        repair = GameObject.FindGameObjectWithTag("Player").GetComponent<RepairShip>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = repair.GetCooldownPercentage();
    }
}
