using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkOverheatValue : MonoBehaviour
{

    public GameObject weaponSlot;

    private Slider overheatSlider;
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        overheatSlider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponSlot.transform.childCount > 0)
        {
            weapon = weaponSlot.transform.GetChild(0).gameObject;
            overheatSlider.value = weapon.GetComponent<FireProjectile>().getCurrentOverheat();
        }
        else
        {
            weapon = null;
            overheatSlider.value = 0;
        }
    }
}
