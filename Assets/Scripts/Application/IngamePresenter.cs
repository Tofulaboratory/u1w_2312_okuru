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

    private readonly IIngameView _ingameView;

    public IngamePresenter(
        IIngameView ingameView,
        Action onTransitionTitle
        )
    {
        _ingameView = ingameView;

        // gameEntity.CurrentGameState.Subscribe(async state =>
        // {
        //     switch (state)
        //     {
        //         case IngameState.INIT:
        //             break;
        //         case IngameState.READY:
        //             await ExecuteReady(gameEntity, _commonCts);
        //             break;
        //         case IngameState.BEGIN:
        //             await ExecuteBeginAsync(gameEntity, _commonCts);
        //             break;
        //         case IngameState.PROGRESS:
        //             break;
        //         case IngameState.WAIT_FRUITS:
        //             ExecuteWaitFruits(gameEntity, _commonCts);
        //             break;
        //         case IngameState.JUDGE:
        //             await ExecuteJudgeAsync(gameEntity, _commonCts);
        //             break;
        //         case IngameState.CHANGE_PLAYER:
        //             await ExecuteChangePlayerAsync(gameEntity, _commonCts);
        //             break;
        //         case IngameState.RESULT:
        //             await ExecuteResultAsync(gameEntity, _commonCts);
        //             break;
        //         case IngameState.END:
        //             await ExecuteEndAsync(gameEntity, _commonCts);
        //             onTransitionTitle.Invoke();
        //             break;
        //         default:
        //             break;
        //     }
        // }).AddTo(_disposable);
    }

    public void Initialize()
    {
        _ingameView.SetActive(true);
    }

    public void Dispose()
    {
        if (!_commonCts.IsCancellationRequested) _commonCts.Cancel();
        _commonCts.Dispose();
        _disposable.Dispose();
    }
}