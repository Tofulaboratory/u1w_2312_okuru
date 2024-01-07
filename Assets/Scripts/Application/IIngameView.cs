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
    public void SetActive(bool isActivate);
}