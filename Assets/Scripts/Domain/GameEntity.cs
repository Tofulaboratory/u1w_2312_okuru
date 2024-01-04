using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameEntity
{
    private readonly ReactiveProperty<GameState> _gameState = new();
    public IReadOnlyReactiveProperty<GameState> CurrentGameState => _gameState;

    private FieldEntity _fieldEntity;
    private PlayerEntity _playerEntity;

    public GameEntity(FieldEntity fieldEntity, PlayerEntity playerEntity)
    {
        _fieldEntity = fieldEntity;
        _playerEntity = playerEntity;
    }

    public bool SetParameter(float value) => _playerEntity.SetParameter(value);
    public Vector3 GetTargetPosition() => _fieldEntity.TargetPosition;
    public PlayerParameterType GetPlayerParameterType() => _playerEntity.Type;

    // public void ExecuteStateEvent(GameState state)
    // {
    //     switch (state)
    //     {
    //         case GameState.READY_GAME:
    //             break;

    //         case GameState.BEGIN_GAME:
    //             break;

    //         case GameState.SELECT_PARAMATER:
    //             break;

    //         case GameState.TAO_PAI_PAI:
    //             break;

    //         case GameState.EVALUATE_SCORE:
    //             break;

    //         case GameState.RESULT:
    //             break;

    //         case GameState.END_GAME:
    //             break;
    //     }
    // }
}
