using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator.Play("armature_idle");
    }
}
