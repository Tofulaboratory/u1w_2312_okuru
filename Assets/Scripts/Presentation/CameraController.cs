using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cvc;
    [SerializeField] private CinemachineFollowZoom cfz;

    public void Apply()
    {
        cfz.m_Width = 0f;
        cfz.m_Damping = 2.37f;
        transform.position = new Vector3(28.41f, 2f, -19.2f);
    }

    public void SetLookAt(Transform transform)
    {
        cvc.LookAt = transform;
    }

    public void SetWidth(float value)
    {
        cfz.m_Width = value;
    }
}
