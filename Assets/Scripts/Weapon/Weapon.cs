using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator animator;
    protected Animator PlayerAnimator { get { return animator; } }

    protected virtual void Start()
    {
        animator = GameManager.Instance.PlayerHealth.GetComponent<Animator>();
    }

    public virtual void Attack() { }

    public virtual void OnAnimationEvent(string eventName) { }
}
