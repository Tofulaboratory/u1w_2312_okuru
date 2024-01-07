using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EarthUnit : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    private float _rot = 0;
    private readonly float SPEED = 0.01f;

    public void Explode()
    {
        var obj = Instantiate(explosionEffect);
        obj.transform.position = this.transform.position;
        obj.transform.localScale = this.transform.localScale;

        Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        _rot += Time.fixedDeltaTime*SPEED;
        transform.eulerAngles += new Vector3(0,_rot,0);
    }
}
