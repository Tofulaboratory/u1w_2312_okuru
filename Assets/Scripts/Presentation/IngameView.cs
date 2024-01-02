using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class IngameView : ViewBase, IIngameView
{
    [SerializeField] private Scrollbar choiseBarV;
    [SerializeField] private Scrollbar choiseBarH;

    private Subject<float> _onDecideParameter = new();
    public IObservable<float> OnDecideParameter() => _onDecideParameter;

    private CancellationTokenSource _moveChoiseBarCts = new();

    public async UniTask StopChoiseBar(BarType type, CancellationToken ct)
    {
        _moveChoiseBarCts?.Cancel();

        //TODO
        await UniTask.Delay(100000, cancellationToken: ct);

        SetActiveChoiseBar(type, false);
    }

    public void StartChoiseBar(BarType type)
    {
        SetActiveChoiseBar(type, true);

        if (!_moveChoiseBarCts.IsCancellationRequested) return;
        _moveChoiseBarCts = new CancellationTokenSource();

        MoveChoiseBar(type, _moveChoiseBarCts.Token).Forget();
    }

    private void SetActiveChoiseBar(BarType type, bool isActivate)
    {
        var bar = GetChoiseBar(type);
        if (bar == null) return;
        bar.gameObject.SetActive(isActivate);
    }

    private async UniTask MoveChoiseBar(BarType type, CancellationToken ct)
    {
        var bar = GetChoiseBar(type);
        if (bar == null) return;

        //TODO
        await UniTask.Delay(100000, cancellationToken: ct);
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