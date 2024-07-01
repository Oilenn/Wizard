using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMovement
{
    public Animator _animator;

    public AnimMovement(Animator animator){
        _animator = animator;
    }

    public void AnimateJump()
    {
        _animator.SetBool("isJumping", true);
    }

    public void UnanimateJump()
    {
        _animator.SetBool("isJumping", false);
    }

    public void AnimateMove()
    {
        _animator.SetBool("isWalking", true);
    }

    public void UnanimateMove()
    {
        _animator.SetBool("isWalking", false);
    }

    public void AnimateAttack()
    {
        _animator.SetBool("isAttacking", true);
    }

    public void UnanimateAttack()
    {
         _animator.SetBool("isAttacking", false);
    }

    public void AnimateRun()
    {
        _animator.SetBool("isRunning", true);
    }

    public void UnanimateRun()
    {
        _animator.SetBool("isRunning", false);
    }
}
