using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaUnit : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject santaCPath;

    private float _resumeAnimationTime = 0;
    private readonly int _throwAnimationKey = Animator.StringToHash("Throw");
    private readonly int _danceAnimationKey = Animator.StringToHash("Dance");

    public void Apply()
    {
        ApplyThrowAnimation(0f,false);
        santaCPath.transform.eulerAngles = new Vector3(0,180,0);
    }

    private void ApplyThrowAnimation(float time = 0, bool isPause = false)
    {
        animator.Play(_throwAnimationKey, 0, time);
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
