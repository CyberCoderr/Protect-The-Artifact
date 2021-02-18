using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACanvasExitText : MonoBehaviour
{

    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("StartFade");
    }
    
}
