using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SantaUnit : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private AnimatorController danceAC;
    [SerializeField] private AnimatorController throwAC;

    public void Apply(PlayerParameterType type)
    {
        Debug.Log(type);
        switch (type)
        {
            case PlayerParameterType.DIRECTIONX:
                break;

            case PlayerParameterType.DIRECTIONY:
                break;

            case PlayerParameterType.POWER:
                break;

            case PlayerParameterType.NECKANGLE:
                break;

            case PlayerParameterType.FACEANGLE:
                break;

            case PlayerParameterType.EYEANGLE:
                break;

            case PlayerParameterType.END:
                break;

            default:
                break;
        }
    }

    public void ApplyThrowAnimation()
    {
        animator.runtimeAnimatorController = throwAC;
    }

    public void ApplyDanceAnimation()
    {
        animator.runtimeAnimatorController = danceAC;
    }
}