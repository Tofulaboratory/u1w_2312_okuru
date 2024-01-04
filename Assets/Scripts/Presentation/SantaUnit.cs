using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SantaUnit : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private AnimatorController danceAC;
    [SerializeField] private AnimatorController throwAC;

    public void ApplyThrowAnimation()
    {
        animator.runtimeAnimatorController = throwAC;
    }

    public void ApplyDanceAnimation()
    {
        animator.runtimeAnimatorController = danceAC;
    }
}
