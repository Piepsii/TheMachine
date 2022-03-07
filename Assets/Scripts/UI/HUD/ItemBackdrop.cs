using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBackdrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.gameObject.CompareTag("WeaponUI"))
        {
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform, true);
        }
    }
}
