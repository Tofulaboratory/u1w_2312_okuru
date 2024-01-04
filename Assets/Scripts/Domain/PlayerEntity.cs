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
            case PlayerParameterType.DIRECTIONX:
            _type = PlayerParameterType.DIRECTIONY;
            _directionX.Value = value;
            return false;

            case PlayerParameterType.DIRECTIONY:
            _type = PlayerParameterType.POWER;
            _directionY.Value = value;
            return false;

            case PlayerParameterType.POWER:
            _type = PlayerParameterType.NECKANGLE;
            _power.Value = value;
            return false;

            case PlayerParameterType.NECKANGLE:
            _type = PlayerParameterType.FACEANGLE;
            _neckAngle.Value = value;
            return false;

            case PlayerParameterType.FACEANGLE:
            _type = PlayerParameterType.EYEANGLE;
            _faceAngle.Value = value;
            return false;

            case PlayerParameterType.EYEANGLE:
            _type = PlayerParameterType.END;
            _eyeAngle.Value = value;
            return true;

            case PlayerParameterType.END:
            return true;

            default:
            return true;
        }
    }
}
