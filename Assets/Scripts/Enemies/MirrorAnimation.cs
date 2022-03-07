using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MirrorAnimation : MonoBehaviour
{
    private Animator animator;
    private AIPath path;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        path = GetComponent<AIPath>();
    }

    void Update()
    {
        if (path.velocity.x < 0f)
            animator.SetBool("IsLeft", true);
        else
            animator.SetBool("IsLeft", false);
    }
}
