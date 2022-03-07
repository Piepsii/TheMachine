using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AddTaggedObjectToPathfinder : MonoBehaviour
{
    [SerializeField]
    private System.String objectTag;

    private Transform destination;
    private AIDestinationSetter dstSetter;

    void Awake()
    {
        destination = GameObject.FindWithTag(objectTag).transform;
        dstSetter = gameObject.GetComponent<AIDestinationSetter>();
        dstSetter.target = destination;
    }

}
