using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IIngameView
{
    public IObserver<bool> OnThrow();
    public void Initialize();
    public void ApplyCount(int value);
    public void ApplyTime(int value);
    public void SetActiveText(bool isActivate);
    public void SetActive(bool isActivate);
}