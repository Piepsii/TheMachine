using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetCursorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] string cursor;

    private GameFunctions gameFunctions;

    void Start()
    {
        gameFunctions = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameFunctions>();
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        gameFunctions.ChangeCursor(cursor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameFunctions.ChangeCursor("crosshair");
    }
}
