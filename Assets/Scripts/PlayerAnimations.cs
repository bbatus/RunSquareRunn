using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SpinAnim();
    }

    public void SpinAnim()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJump", false);
        }
    }
}
