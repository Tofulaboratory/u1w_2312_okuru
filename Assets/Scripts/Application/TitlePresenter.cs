using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using VContainer;

public class TitlePresenter : IDisposable
{
    private readonly CompositeDisposable _disposable = new();

    private readonly ITitleView _titleView;
    private readonly Action _onTransitionGame;

    public TitlePresenter(
        ITitleView titleView,
        Action onTransitionGame
        )
    {
        _titleView = titleView;
        _onTransitionGame = onTransitionGame;
    }

    public async UniTask InitializeAsync()
    {
        _titleView.SetActive(true);

        await UniTask.WaitUntil(()=>InputEventProvider.Instance.GetKeyDownSpaceObservable!=null); // TODO Cancellation token
        InputEventProvider.Instance.GetKeyDownSpaceObservable.Where(item=>item).Subscribe(_=>{
            _onTransitionGame.Invoke();
            _titleView.SetActive(false);
        }).AddTo(_disposable);
    }

    public void Dispose()
    {
        _disposable.Dispose();
    }
}
