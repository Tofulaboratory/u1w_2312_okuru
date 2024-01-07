using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using unityroom.Api;

public class ResultPresenter : IDisposable
{
    private readonly CompositeDisposable _disposable = new();

    private readonly IResultView _resultView;
    private readonly GameEntity _gameEntity;
    private readonly Action _onTransition;

    public ResultPresenter(
        IResultView resultView,
        GameEntity gameEntity,
        Action onTransition
        )
    {
        _resultView = resultView;
        _gameEntity = gameEntity;
        _onTransition = onTransition;
    }

    public async UniTask InitializeAsync()
    {
        _resultView.SetActive(true);
        _resultView.ApplyCount(_gameEntity.Cnt.Value);
        UnityroomApiClient.Instance.SendScore(1, _gameEntity.Cnt.Value, ScoreboardWriteMode.HighScoreDesc);

        await UniTask.Delay(3000);
        await UniTask.WaitUntil(()=>InputEventProvider.Instance.GetKeyDownSpaceObservable!=null); // TODO Cancellation token
        InputEventProvider.Instance.GetKeyDownSpaceObservable.Where(item=>item).Subscribe(_=>{
            _onTransition.Invoke();
            _resultView.SetActive(false);
        }).AddTo(_disposable);
    }

    public void Dispose()
    {
        _disposable.Dispose();
    }
}
