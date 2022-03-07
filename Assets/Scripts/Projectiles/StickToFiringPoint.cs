using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToFiringPoint : MonoBehaviour
{
    private GameObject firingPoint;
    // Start is called before the first frame update
    void Start()
    {
        firingPoint =  GameObject.FindGameObjectWithTag("PlayerFiringPoint");
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(firingPoint.transform.position, firingPoint.transform.rotation);
    }
}
