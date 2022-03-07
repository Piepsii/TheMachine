using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSeamlessMusic : MonoBehaviour
{

    void Awake()
    {
        GameObject MenuMusic = GameObject.FindGameObjectWithTag("MenuMusic");

        Destroy(MenuMusic);
    }

}
