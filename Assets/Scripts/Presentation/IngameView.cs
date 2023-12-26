using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class IngameView : ViewBase, IIngameView
{
    private Subject<float> _onDecideParameter = new();
    public IObservable<float> OnDecideParameter() => _onDecideParameter;

    public void StopChoiseBarV()
    {
        
    }

    public void SetActive(bool isActivate)
    {
        base.SetActiveCanvasGroup(isActivate);
    }
}
