using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    [SerializeField]
    private float RotationSpeed = 20;

    private Transform ObjTransform;

    void Start()
    {
        ObjTransform = transform;   
    }

    void Update()
    {
        ObjTransform.Rotate(0, 0, RotationSpeed);
    }
}
