using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject gameHandler;

    void OnEnable()
    {
        gameHandler.GetComponent<GameFunctions>().ToggleGameTime(0);
    }

    void OnDisable()
    {
        if(gameHandler != null)
            gameHandler.GetComponent<GameFunctions>().ToggleGameTime(1);
    }
}
