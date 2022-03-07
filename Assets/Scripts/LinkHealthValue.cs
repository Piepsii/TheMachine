using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkHealthValue : MonoBehaviour
{

    private Slider slider;
    public PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.CurrentHealth;

    }
}
