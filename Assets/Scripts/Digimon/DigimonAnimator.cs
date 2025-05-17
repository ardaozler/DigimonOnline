using UnityEngine;
using System;

//proxy/facade pattern(?)
public class DigimonAnimator : MonoBehaviour
{
    private Animator _animator;

    public event Action<string> OnAnimationComplete;

    [SerializeField] private Animator animator;

    public void PlayWalkAnimation()
    {
        animator.SetTrigger("IsMoving");
    }

    public void PlayEatAnimation()
    {
        animator.SetTrigger("Eat");
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetTrigger(string mood)
    {
        _animator.SetTrigger(mood);
    }

    public void PlayClip(string clipName)
    {
        _animator.Play(clipName);
    }

    public void SetBool(string paramName, bool value)
    {
        _animator.SetBool(paramName, value);
    }

    public void SetFloat(string paramName, float value)
    {
        _animator.SetFloat(paramName, value);
    }

    // Called from Animation Event (see below)
    public void NotifyAnimationComplete(string animationName)
    {
        OnAnimationComplete?.Invoke(animationName);
    }
}