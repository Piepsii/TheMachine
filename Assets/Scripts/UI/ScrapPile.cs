using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrapPile : MonoBehaviour
{

    public int minimum = 2;
    public int maximum = 5;
    private GameObject scrapCounter;

    private GameObject target;



    void Start()
    {
        scrapCounter = GameObject.FindGameObjectWithTag("ScrapCounter");
        target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("CollectScrap");

    }


    IEnumerator CollectScrap()
    {
        for(float f = 0; f < 1.0f; f += .001f)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, f);
            if (f > 0.1f)
            {
                scrapCounter.GetComponent<ManageScrap>().addScrap(minimum, maximum);
                Destroy(gameObject);
            }
            yield return null;
        }
    }

    
}
