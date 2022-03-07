using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSlots : MonoBehaviour
{
    public KeyCode ShootSlot1 = KeyCode.None;
    public KeyCode ShootSlot2 = KeyCode.None;
    public KeyCode ShootSlot3 = KeyCode.None;
    public KeyCode ShootSlot4 = KeyCode.None;

    private Transform backdrop;
    // public FireProjectile[] fireProjectiles = new FireProjectile[5];

    void Start()
    {
        backdrop = GameObject.FindGameObjectWithTag("ItemBackdrop").transform;
    }

    void Update()
    {

        if (Input.GetKey(ShootSlot1))
        {
            if (Input.GetKeyDown(ShootSlot1))
                FireSlot(1, false);

            else
                FireSlot(1, true);
        }

        if (Input.GetKey(ShootSlot2))
        {
            if (Input.GetKeyDown(ShootSlot2))
                FireSlot(2, false);

            else
                FireSlot(2, true);
        }

        if (Input.GetKey(ShootSlot3))
        {
            if (Input.GetKeyDown(ShootSlot3))
                FireSlot(3, false);

            else
                FireSlot(3, true);
        }

        if (Input.GetKey(ShootSlot4))
        {
            if (Input.GetKeyDown(ShootSlot4))
                FireSlot(4, false);

            else
                FireSlot(4, true);
        }

    }

    void FireSlot(int id, bool hold)
    {
        id--;

        if (id > transform.childCount)
            Debug.LogError("Parent does not have that many children");

        if (transform.GetChild(id).childCount > 0)
        {
            transform.GetChild(id).GetChild(0).GetComponent<FireProjectile>().Fire(hold);
        }
    }
    public Transform FindEmptySlot()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.childCount == 0)
                return child;
        }
        return backdrop;
    }

    public bool HasEmptySlot()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.childCount == 0)
                return true;
        }
        return false;
    }
    public void SetBlocksRaycastsForSlots(bool value)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.childCount != 0)
                child.GetComponent<CanvasGroup>().blocksRaycasts = value;
        }
    }

    public void SetBlocksRaycastsForWeapons(bool value)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.childCount != 0)
                child.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = value;
        }
    }

    public void AddWeaponToEmptySlot(GameObject weapon)
    {
        if (!HasEmptySlot())
            return;

        Transform empty = FindEmptySlot();
        Instantiate(weapon, empty);
    }
}
