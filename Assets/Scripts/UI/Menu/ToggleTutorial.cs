using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTutorial : MonoBehaviour
{
    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = WaveSpawner.tutorialIsActive;
        toggle.onValueChanged.AddListener(delegate
        {
            ToggleTutorialIsActive();
        });
    }


    void ToggleTutorialIsActive()
    {
        WaveSpawner.tutorialIsActive = toggle.isOn;
    }
}
