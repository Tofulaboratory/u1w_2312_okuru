using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SantaUnit : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject santaCPath;

    private float _resumeAnimationTime = 0;
    private readonly int _throwAnimationKey = Animator.StringToHash("Throw");
    private readonly int _danceAnimationKey = Animator.StringToHash("Dance");

    public void Apply(PlayerParameterType type)
    {
        Debug.Log(type);
        switch (type)
        {
            case PlayerParameterType.BEGIN:
                ApplyThrowAnimation(0.25f,true);
                santaCPath.transform.eulerAngles = new Vector3(0,180,0);
                break;

            case PlayerParameterType.DIRECTIONX:
                break;

            case PlayerParameterType.POWER:
                break;

            case PlayerParameterType.END:
                break;

            default:
                break;
        }
    }

    private void ApplyThrowAnimation(float time = 0, bool isPause = false)
    {
        animator.Play(_throwAnimationKey, 0, time);
        //animator.enabled = !isPause;
        animator.speed = isPause ? 0 : 1;
    }

    private void ApplyDanceAnimation(float time = 0, bool isPause = false)
    {
        animator.Play(_throwAnimationKey, 0, time);
        animator.speed = isPause ? 0 : 1;
    }

    private void PauseAnimation()
    {
        animator.enabled = false;
        _resumeAnimationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
