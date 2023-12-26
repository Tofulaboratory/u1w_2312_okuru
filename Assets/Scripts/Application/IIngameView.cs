using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IIngameView
{
    public IObservable<float> OnDecideParameter();
    public void StopChoiseBarV();
    public void SetActive(bool isActivate);
}