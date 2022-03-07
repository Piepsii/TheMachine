using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWeaponToSlot : MonoBehaviour
{
    [SerializeField] private GameObject weapon;

    private ManageSlots weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GameObject.FindGameObjectWithTag("Weapon Manager").GetComponent<ManageSlots>();
        weaponManager.AddWeaponToEmptySlot(weapon);
    }
}
