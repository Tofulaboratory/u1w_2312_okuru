using UnityEngine;

public class FieldEntity
{
    public Vector3 TargetPosition {get; private set;}
    public FieldEntity(Vector3 targetPosition)
    {
        TargetPosition = targetPosition;
    }
}
