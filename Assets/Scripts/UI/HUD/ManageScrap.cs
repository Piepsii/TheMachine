using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScrap : MonoBehaviour
{

    public int amount = 0;

    public Text value;

    private void Start()
    {
        updateScrap();
    }

    public void addScrap(int minimum, int maximum)
    {
        amount += Random.Range(minimum, maximum + 1);
        updateScrap();
    }

    public void updateScrap()
    {
        value.text = amount + " x";
    }
}
