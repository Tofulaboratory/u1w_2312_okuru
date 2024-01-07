using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerEntity
{
    private PlayerParameterType _type = PlayerParameterType.POWER;
    public PlayerParameterType Type => _type;

    private readonly ReactiveProperty<float> _power = new();
    public IReadOnlyReactiveProperty<float> Power => _power;

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
