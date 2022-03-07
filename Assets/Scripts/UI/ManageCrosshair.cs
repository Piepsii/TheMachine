using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCrosshair : MonoBehaviour
{

    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private Camera uiCam;


    // Update is called once per frame
    void Update()
    {
        crosshair.transform.position = uiCam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }
}
