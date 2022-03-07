using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ManageSlots manager;

    private bool inUse;
    private CanvasGroup canvasGroup;
    private Transform weapon;

    void Start()
    {
        inUse = false;
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if(transform.childCount > 0)
        {
            inUse = true;
            weapon = transform.GetChild(0).GetComponent<RectTransform>();
        } else
        {
            inUse = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || !eventData.pointerDrag.CompareTag("WeaponUI"))
            return;

        Transform draggedItem = eventData.pointerDrag.transform;

        if (inUse && manager.HasEmptySlot())
        {
            Transform emptySlot = manager.FindEmptySlot();
            weapon.SetParent(emptySlot, true);
            weapon.position = emptySlot.position;
            inUse = false;
        }

        if (!inUse)
        {
            draggedItem.position = GetComponent<RectTransform>().position;
            draggedItem.SetParent(transform, true);
            inUse = true;
        }
    }

    public void ToggleBlocksRaycasts(bool toggle)
    {
        if (inUse)
            canvasGroup.blocksRaycasts = toggle;
        else
            canvasGroup.blocksRaycasts = true;
    }

}
