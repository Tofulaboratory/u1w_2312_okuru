using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class IngamePresenter : IDisposable
{
    private readonly CompositeDisposable _disposable = new();
    private CancellationTokenSource _commonCts = new();
    private readonly Action _onTransition;

    private readonly IIngameView _ingameView;
    private readonly GameEntity _gameEntity;

    public IngamePresenter(
        IIngameView ingameView,
        GameEntity gameEntity,
        Action onTransition
        )
    {
        _ingameView = ingameView;
        _gameEntity = gameEntity;
        _onTransition = onTransition;
    }

    public void Initialize()
    {
        _ingameView.SetActive(true);
        _ingameView.Initialize();

        InputEventProvider.Instance.GetKeyDownSpaceObservable.Subscribe(async _ =>
        {
            _ingameView.OnThrow().OnNext(true);
            await UniTask.Delay(6000);
            _onTransition.Invoke();
        }).AddTo(_disposable);
    }

    public void Dispose()
    {
        if (!_commonCts.IsCancellationRequested) _commonCts.Cancel();
        _commonCts.Dispose();
        _disposable.Dispose();
    }
}
