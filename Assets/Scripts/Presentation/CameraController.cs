using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFollowZoom cfz;

    public void Apply(PlayerParameterType type)
    {
        Debug.Log(type);
        switch (type)
        {
            case PlayerParameterType.BEGIN:
                cfz.m_Width = 5.8f;
                cfz.m_Damping = 2.37f;
                transform.position = new Vector3(21.7f, 3.45f, 18f);
                break;

            case PlayerParameterType.DIRECTIONX:

                break;

            case PlayerParameterType.POWER:
                break;

            case PlayerParameterType.END:
                break;

            default:
                break;
        }
    }
}
