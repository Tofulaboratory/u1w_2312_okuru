using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory
{
    private PlayerEntity CreateEntity() => new();

    public PlayerEntity Create()
    {
        return CreateEntity();
    }
}
