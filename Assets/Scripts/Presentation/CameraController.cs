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
                cfz.m_Width = 0f;
                cfz.m_Damping = 2.37f;
                transform.position = new Vector3(28.41f, 2f, -19.2f);
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
