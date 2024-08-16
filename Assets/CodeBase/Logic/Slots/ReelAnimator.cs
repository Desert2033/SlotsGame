using UnityEngine;
using System;
using System.Collections.Generic;


[RequireComponent(typeof(Animator))]
public class ReelAnimator : MonoBehaviour
{
    private const string AnimationTrigger = "RoleTrigger";

    private Animator _animator;
    private Action _afterAnimation;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartRole(Action afterAnimation)
    {
        _animator.SetTrigger(AnimationTrigger);

        _afterAnimation = afterAnimation;
    }

    private void HandleEndRole()
    {
        _afterAnimation?.Invoke();
    }
}
