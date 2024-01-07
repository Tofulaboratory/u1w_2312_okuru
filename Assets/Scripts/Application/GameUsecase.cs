using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using VContainer;
using UnityEngine.SceneManagement;

public class GameUsecase : IDisposable
{
    private CompositeDisposable _disposable = new();

    private readonly ReactiveProperty<OutgameState> _outgameState = new();
    public void ChangeOutgameState(OutgameState state) => _outgameState.Value = state;

    private readonly ITitleView _titleView;
    private readonly IIngameView _ingameView;
    private readonly IResultView _resultView;
    private readonly GameFactory _gameFactory;

    private GameEntity _gameEntity;

    private TitlePresenter titlePresenter;
    private IngamePresenter ingamePresenter;
    private ResultPresenter resultPresenter;

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

                case OutgameState.RESULT:
                    InitializeResult();
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
        titlePresenter.InitializeAsync().Forget();
    }

    private void InitializeIngame()
    {
        _gameEntity = _gameFactory.Create();

        ingamePresenter?.Dispose();
        ingamePresenter = new IngamePresenter(
            _ingameView,
            _gameEntity,
            () => ChangeOutgameState(OutgameState.RESULT)
        );
        ingamePresenter.Initialize();
    }

    private void InitializeResult()
    {
        resultPresenter?.Dispose();
        resultPresenter = new ResultPresenter(
            _resultView,
            () => SceneManager.LoadScene("Core")
        );
        resultPresenter.InitializeAsync().Forget();
    }

    public void Dispose()
    {
        titlePresenter?.Dispose();
        ingamePresenter?.Dispose();
        resultPresenter?.Dispose();
        _disposable?.Dispose();

        GC.SuppressFinalize(this);
    }
}