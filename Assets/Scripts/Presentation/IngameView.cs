using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IngameView : ViewBase, IIngameView
{
    [SerializeField] private SantaUnit santaUnit;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PresentUnit presentUnit;

    private Subject<bool> _onThrow = new();
    public IObserver<bool> OnThrow() => _onThrow;

    private Scrollbar _currentActiveScrollbar = null;

    private CancellationTokenSource _moveChoiseBarCts = new();

    public void Initialize()
    {
        cameraController.Apply();
        santaUnit.Apply();

        _onThrow.Subscribe(_ =>
        {
            presentUnit.MoveToGoalAsync().Forget();
            cameraController.SetLookAt(presentUnit.transform);
            cameraController.SetWidth(500);
        }).AddTo(this);
    }

    // var seq = DOTween
    //     .Sequence()
    //     .PrependCallback(() => bar.value = 0)
    //     .Append(
    //         DOTween.To(() => bar.value, (value) => bar.value = value, 1, CHOISE_BAR_LOOP_DURATION).SetEase(Ease.InOutSine)
    //         )
    //     .SetLoops(-1, LoopType.Yoyo)
    //     .WithCancellation(ct);

    public void SetActive(bool isActivate)
    {
        base.SetActiveCanvasGroup(isActivate);
    }
}