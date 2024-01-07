using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthUnit : MonoBehaviour
{
    private float _rot = 0;
    private readonly float SPEED = 0.01f;

    void FixedUpdate()
    {
        _rot += Time.fixedDeltaTime*SPEED;
        transform.eulerAngles += new Vector3(0,_rot,0);
    }
}
