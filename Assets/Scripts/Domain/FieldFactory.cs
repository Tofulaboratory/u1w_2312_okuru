using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldFactory
{
    // TODO 位置情報
    private FieldEntity CreateEntity() => new(new Vector3(1,1,1));

    public FieldEntity Create()
    {
        return CreateEntity();
    }
}
