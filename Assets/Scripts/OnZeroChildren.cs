using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnZeroChildren : MonoBehaviour
{
    public GameObject Object;

    private void Update()
    {
        if(transform.childCount == 0)
        {
            Object.SetActive(true);
        }

    }
}
