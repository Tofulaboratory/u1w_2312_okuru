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
    [SerializeField] private Scrollbar choiseBarV;
    [SerializeField] private Scrollbar choiseBarH;

    [SerializeField] private SantaUnit santaUnit;
    [SerializeField] private CameraController cameraController;

    private readonly float CHOISE_BAR_LOOP_DURATION = 1;
    private readonly int CHOISE_BAR_CLOSE_DURATION = 500;

    private Subject<float> _onDecideParameter = new();
    public IObservable<float> OnDecideParameter() => _onDecideParameter;

    private Subject<PlayerParameterType> _triggerDecideParameter = new();
    public IObserver<PlayerParameterType> TriggerDecideParameter() => _triggerDecideParameter;

    private Scrollbar _currentActiveScrollbar = null;

    private CancellationTokenSource _moveChoiseBarCts = new();

    public void Initialize()
    {
        cameraController.Apply(PlayerParameterType.BEGIN);
        santaUnit.Apply(PlayerParameterType.BEGIN);

        _triggerDecideParameter.Subscribe(async value =>
        {
            var bar = _currentActiveScrollbar;
            if (bar == null) return;

            _onDecideParameter.OnNext(bar.value);
            StopChoiseBar();

            if(value != PlayerParameterType.EYEANGLE)
            {
                await UniTask.Delay(CHOISE_BAR_CLOSE_DURATION);
                cameraController.Apply(value);
                santaUnit.Apply(value);
                StartChoiseBar(BarType.Vertical);
            }
        }).AddTo(this);
    }

    public void StartChoiseBar(BarType type)
    {
        SetActiveChoiseBar(type, true);
        _moveChoiseBarCts = new CancellationTokenSource();
        MoveChoiseBar(type, _moveChoiseBarCts.Token).Forget();
    }

    private void StopChoiseBar()
    {
        _moveChoiseBarCts?.Cancel();
        SetActiveChoiseBar(BarType.Vertical, false);
        SetActiveChoiseBar(BarType.Horizontal, false);
    }

    private void SetActiveChoiseBar(BarType type, bool isActivate)
    {
        var bar = GetChoiseBar(type);
        if (bar == null) return;
        bar.gameObject.SetActive(isActivate);
        if (isActivate)
        {
            _currentActiveScrollbar = bar;
        }
        else
        {
            _currentActiveScrollbar = null;
        }
    }

    private async UniTask MoveChoiseBar(BarType type, CancellationToken ct)
    {
        var bar = GetChoiseBar(type);
        if (bar == null) return;

        var seq = DOTween
            .Sequence()
            .PrependCallback(() => bar.value = 0)
            .Append(
                DOTween.To(() => bar.value, (value) => bar.value = value, 1, CHOISE_BAR_LOOP_DURATION).SetEase(Ease.InOutSine)
                )
            .SetLoops(-1, LoopType.Yoyo)
            .WithCancellation(ct);

        await seq;
    }

    private Scrollbar GetChoiseBar(BarType type)
    {
        switch (type)
        {
            case BarType.Vertical: return choiseBarV;
            case BarType.Horizontal: return choiseBarH;
            default: return null;
        }
    }

    public void SetActive(bool isActivate)
    {
        base.SetActiveCanvasGroup(isActivate);
    }
}