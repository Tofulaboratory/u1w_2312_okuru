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

    private bool canCnt = true;

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

    public async void Initialize()
    {
        _ingameView.SetActive(true);
        _ingameView.Initialize();

        _gameEntity.Cnt.Subscribe(value=>{
            if(!canCnt) return;
            _ingameView.ApplyCount(value);
            AudioManager.Instance.PlaySE("Atk");
        }).AddTo(_disposable);

        InputEventProvider.Instance.GetKeyDownSpaceObservable.Subscribe(_ =>
        {
            _gameEntity.AddCnt();
        }).AddTo(_disposable);

        await WaitThrow(10);
        AudioManager.Instance.PlaySE("Inj");
        AudioManager.Instance.PlaySE("ha");
        canCnt = false;

        _ingameView.SetActiveText(false);
        _ingameView.OnThrow().OnNext(true);
        await UniTask.Delay(6000);
        _onTransition.Invoke();
    }

    private async UniTask WaitThrow(int seconds)
    {
        for(int i = seconds;i>=1;i--)
        {
            _ingameView.ApplyTime(i);
            if(i<=3)
            {
                AudioManager.Instance.PlaySE("count");
            }
            await UniTask.Delay(1000);
        }
    }

    public void Dispose()
    {
        if (!_commonCts.IsCancellationRequested) _commonCts.Cancel();
        _commonCts.Dispose();
        _disposable.Dispose();
    }
}
