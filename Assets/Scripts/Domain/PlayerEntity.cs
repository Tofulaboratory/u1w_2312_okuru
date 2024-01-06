using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerEntity
{
    private PlayerParameterType _type = PlayerParameterType.DIRECTIONX;
    public PlayerParameterType Type => _type;

    private readonly ReactiveProperty<float> _directionX = new();
    public IReadOnlyReactiveProperty<float> DirectionX => _directionX;

    private readonly ReactiveProperty<float> _directionY = new();
    public IReadOnlyReactiveProperty<float> DirectionY => _directionY;

    private readonly ReactiveProperty<float> _power = new();
    public IReadOnlyReactiveProperty<float> Power => _power;

    private readonly ReactiveProperty<float> _neckAngle = new();
    public IReadOnlyReactiveProperty<float> NeckAngle => _neckAngle;

    private readonly ReactiveProperty<float> _faceAngle = new();
    public IReadOnlyReactiveProperty<float> FaceAngle => _faceAngle;

    private readonly ReactiveProperty<float> _eyeAngle = new();
    public IReadOnlyReactiveProperty<float> EyeAngle => _eyeAngle;

    public PlayerEntity()
    {

    }

    public bool SetParameter(float value)
    {
        Debug.Log($"{_type}:{value}");
        switch(_type)
        {
            case PlayerParameterType.BEGIN:
            return false;

            case PlayerParameterType.DIRECTIONX:
            _type = PlayerParameterType.POWER;
            _directionX.Value = value;
            return false;

            case PlayerParameterType.POWER:
            _type = PlayerParameterType.END;
            _power.Value = value;
            return false;

            case PlayerParameterType.END:
            return true;

            default:
            return true;
        }
    }
}
