using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleProperties : MonoBehaviour
{
    private enum Direction 
    { 
        NORTH,
        EAST,
        SOUTH,
        WEST,
        RANDOM,
        EAST_WEST,
        NORTH_SOUTH,
    }

    [SerializeField] private Direction direction;
    [SerializeField] private float timeUntilNextRipple;

    public int difficultyValue;

    void Update()
    {
        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }

        CalculateDifficulty();
    }

    private void CalculateDifficulty()
    {
        List<Difficulty> children = new List<Difficulty>();
        GetComponentsInChildren<Difficulty>(true, children);
        foreach (Difficulty child in children)
        {
            difficultyValue += child.difficultyValue;
        }
    }

    public float GetTimeUntilNextRipple()
    {
        return timeUntilNextRipple;
    }

    public int GetDirection()
    {
        return (int) direction;
    }
}
