using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class CoreLifeTimeScope : LifetimeScope
{

    [SerializeField] private TitleView _titleView;
    [SerializeField] private IngameView _ingameView;
    [SerializeField] private ResultView _resultView;
    [SerializeField] private SettingView _settingView;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameFactory>(Lifetime.Scoped);
        builder.Register<FieldFactory>(Lifetime.Scoped);
        builder.Register<PlayerFactory>(Lifetime.Scoped);
        builder.RegisterEntryPoint<GameInitializer>();
        builder.Register<GameUsecase>(Lifetime.Scoped);

        builder.RegisterInstance(_titleView).As<ITitleView>();
        builder.RegisterInstance(_ingameView).As<IIngameView>();
        builder.RegisterInstance(_resultView).As<IResultView>();
        builder.RegisterInstance(_settingView).As<ISettingView>();
    }
}