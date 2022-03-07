using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 10 || transform.position.x <= -10)
            Destroy(gameObject);

        else if (transform.position.y >= 6 || transform.position.y <= -6)
            Destroy(gameObject);
    }
}
