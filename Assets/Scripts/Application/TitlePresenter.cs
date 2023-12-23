using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using VContainer;

public class TitlePresenter : IDisposable
{
    private readonly CompositeDisposable _disposable = new();

    private readonly ITitleView _titleView;

    public TitlePresenter(
        ITitleView titleView,
        Action onTransitionGame
        )
    {
        _titleView = titleView;
    }

    public void Initialize()
    {
        _titleView?.SetActive(true);
    }

    public void Dispose()
    {
        _disposable.Dispose();
    }
}
