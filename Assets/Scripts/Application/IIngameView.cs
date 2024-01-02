using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IIngameView
{
    public IObservable<float> OnDecideParameter();
    public UniTask StopChoiseBar(BarType type, CancellationToken ct);
    public void StartChoiseBar(BarType type);
    public void SetActive(bool isActivate);
}