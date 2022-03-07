using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatBar : MonoBehaviour
{

    public GameObject weaponSlot;

    private Slider overheatSlider;
    private GameObject weapon;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        overheatSlider = gameObject.GetComponent<Slider>();
        fill.color = gradient.Evaluate(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponSlot.transform.childCount > 0)
        {
            weapon = weaponSlot.transform.GetChild(0).gameObject;
            overheatSlider.value = weapon.GetComponent<FireProjectile>().getCurrentOverheat();
            fill.color = gradient.Evaluate(overheatSlider.normalizedValue);
        }
        else
        {
            weapon = null;
            overheatSlider.value = 0;
        }
    }
}
