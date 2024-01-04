using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameFactory
{
    private readonly FieldFactory _fieldFactory;
    private readonly PlayerFactory _playerFactory;

    [Inject]
    public GameFactory(FieldFactory fieldFactory, PlayerFactory playerFactory)
    {
        _fieldFactory = fieldFactory;
        _playerFactory = playerFactory;
    }

    private GameEntity CreateEntity(FieldEntity fieldEntity, PlayerEntity playerEntity) => new(fieldEntity,playerEntity);

    public GameEntity Create()
    {
        return CreateEntity(
            _fieldFactory.Create(),
            _playerFactory.Create()
        );
    }
}
