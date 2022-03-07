using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShoot : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject crosshair;
    public GameObject playerFiringHolder;
    public GameObject playerFiringPoint;

    private Vector3 target;

    private GameFunctions gameFunctions;

    void Start()
    {
        gameFunctions = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameFunctions>();
        gameFunctions.ChangeCursor("crosshair");
    }

    void Update()
    {
        target = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        crosshair.transform.position = new Vector3(target.x, target.y, -4);

        Vector2 difference = target - playerFiringHolder.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        playerFiringHolder.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
}