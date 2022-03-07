using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemCatch : MonoBehaviour, IDropHandler
{
    Transform weaponManager;

    void Start()
    {
        weaponManager = GameObject.FindGameObjectWithTag("Weapon Manager").transform;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.gameObject.CompareTag("WeaponUI"))
        {
            Transform emptySlot = weaponManager.GetComponent<ManageSlots>().FindEmptySlot();
            RectTransform draggedItem = eventData.pointerDrag.GetComponent<RectTransform>();
            draggedItem.SetParent(emptySlot, true);
            draggedItem.position = emptySlot.position;
        }
    }


}
