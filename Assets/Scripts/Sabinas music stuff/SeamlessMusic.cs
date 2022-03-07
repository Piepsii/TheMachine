using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessMusic : MonoBehaviour
{
    private static SeamlessMusic seamlessMannagerInstance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (seamlessMannagerInstance == null)
        {
            seamlessMannagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
