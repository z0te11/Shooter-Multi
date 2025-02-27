using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    protected Animator animator;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void Move(bool isMove)
    {
        animator.SetBool("Walking", isMove);
    }

    public virtual void GetHit()
    {
        animator.SetTrigger("Hit");
    }

    public virtual void Die()
    {
        animator.SetTrigger("Die");
    }

    public virtual void Attack()
    {
        animator.SetTrigger("Attack");
    }


}
