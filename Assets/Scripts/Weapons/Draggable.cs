// source: https://carlhalstead.wordpress.com/2017/07/30/unity-draggable-ui-script/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Camera mainCam;
    private RectTransform rect;
    private CanvasGroup canvasGroup;
    private Transform weaponManager;
    private Transform canvas;
    private GameFunctions gameFunctions;

    private void Awake()
    {
        mainCam = Camera.main;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        weaponManager = GameObject.FindGameObjectWithTag("Weapon Manager").transform;
        gameFunctions = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameFunctions>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        weaponManager.GetComponent<ManageSlots>().SetBlocksRaycastsForWeapons(false);
       // weaponManager.GetComponent<ManageSlots>().SetBlocksRaycastsForSlots(false);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.transform.localScale *= 1.2f;
        transform.SetParent(canvas);
        gameFunctions.ChangeCursor("grabbing");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 fixedMousePos = GetClampedMousePosition(eventData.position);
        rect.position = fixedMousePos;
        gameFunctions.ChangeCursor("grabbing");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        weaponManager.GetComponent<ManageSlots>().SetBlocksRaycastsForWeapons(true);
        //weaponManager.GetComponent<ManageSlots>().SetBlocksRaycastsForSlots(true);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.transform.localScale *= 1/1.2f;
        gameFunctions.ChangeCursor("holding");
    }


    private Vector3 GetClampedMousePosition(Vector3 mousePos)
    {
        return mainCam.ScreenToWorldPoint(
            new Vector3(
            Mathf.Clamp(mousePos.x, 0, Screen.width),
            Mathf.Clamp(mousePos.y, 0, Screen.height),
            10f
            )
        );
    }

}
