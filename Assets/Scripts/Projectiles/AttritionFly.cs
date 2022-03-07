using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttritionFly : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private float SpeedLostPerSecond;

    // Update is called once per frame
    void Update()
    {
        if (Speed > 0.1)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * Speed;
            Speed -= SpeedLostPerSecond * Time.deltaTime;
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * 0;
        }
    }
}
