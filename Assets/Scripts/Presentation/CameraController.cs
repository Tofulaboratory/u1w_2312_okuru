using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;

    public void Apply(PlayerParameterType type)
    {
        Debug.Log(type);
        switch (type)
        {
            case PlayerParameterType.BEGIN:
                break;

            case PlayerParameterType.DIRECTIONX:
                break;

            case PlayerParameterType.DIRECTIONY:
                break;

            case PlayerParameterType.POWER:
                break;

            case PlayerParameterType.NECKANGLE:
                break;

            case PlayerParameterType.FACEANGLE:
                break;

            case PlayerParameterType.EYEANGLE:
                break;

            case PlayerParameterType.END:
                break;

            default:
                break;
        }
    }
}
