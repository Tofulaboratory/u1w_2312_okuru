using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class PresentUnit : MonoBehaviour
{
    private readonly Vector3 GOAL_POS = new Vector3(-238.6058f,150.5633f,-342.7186f);

    public async UniTask MoveToGoalAsync(float duration)
    {
        this.transform.parent = null;
        await transform.DOLocalMove(GOAL_POS,duration);
    }
}
