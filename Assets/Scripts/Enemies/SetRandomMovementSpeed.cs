using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SetRandomMovementSpeed : MonoBehaviour
{
    private AIPath path;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float variance;

    void Start()
    {
        path = gameObject.GetComponent<AIPath>();
        path.maxSpeed = Random.Range(movementSpeed - variance, movementSpeed + variance);
    }
}
