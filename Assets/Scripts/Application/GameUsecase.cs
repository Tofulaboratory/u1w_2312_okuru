using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using VContainer;

public class GameUsecase : IDisposable
{
    private CompositeDisposable _disposable = new();

    private readonly ReactiveProperty<OutgameState> _outgameState = new();
    public void ChangeOutgameState(OutgameState state) => _outgameState.Value = state;

    private readonly ITitleView _titleView;
    private readonly IIngameView _ingameView;
    private readonly IResultView _resultView;
    private readonly GameFactory _gameFactory;

    private TitlePresenter titlePresenter;
    private IngamePresenter ingamePresenter;

    [Inject]
    public GameUsecase(
        ITitleView titleView,
        IIngameView ingameView,
        IResultView resultView,
        GameFactory gameFactory
        )
    {
        _titleView = titleView;
        _ingameView = ingameView;
        _resultView = resultView;
        _gameFactory = gameFactory;

        _outgameState.Subscribe(state =>
        {
            //Debug.Log(state);
            switch (state)
            {
                case OutgameState.TITLE:
                    InitializeTitle();
                    break;

                case OutgameState.INGAME:
                    InitializeIngame();
                    break;

                default:
                    break;
            }
        }).AddTo(_disposable);

        AudioManager.Instance.Initialize();
        AudioManager.Instance.PlayBGM("Title");
    }

    ~GameUsecase()
    {
        Dispose();
    }

    private void InitializeTitle()
    {
        titlePresenter?.Dispose();
        titlePresenter = new TitlePresenter(
            _titleView,
            () => ChangeOutgameState(OutgameState.INGAME)
        );
        titlePresenter.Initialize();
    }

    private void InitializeIngame()
    {
        ingamePresenter?.Dispose();
        ingamePresenter = new IngamePresenter(
            _ingameView,
            () => ChangeOutgameState(OutgameState.TITLE)
        );
        ingamePresenter.Initialize();
    }

    public void Dispose()
    {
        titlePresenter?.Dispose();
        ingamePresenter?.Dispose();
        _disposable?.Dispose();

        GC.SuppressFinalize(this);
    }
}