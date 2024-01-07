using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameFactory
{
    public GameFactory()
    {
    }

    private GameEntity CreateEntity() => new();

    public GameEntity Create()
    {
        return CreateEntity();
    }
}
