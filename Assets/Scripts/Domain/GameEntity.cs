using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameEntity
{
    private readonly ReactiveProperty<GameState> _gameState = new();
    public IReadOnlyReactiveProperty<GameState> CurrentGameState => _gameState;

    public GameEntity()
    {
    }

    private ReactiveProperty<int> _cnt = new();
    public IReadOnlyReactiveProperty<int> Cnt => _cnt;

    public void AddCnt()=>_cnt.Value++;
}
