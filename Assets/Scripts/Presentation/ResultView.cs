using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : ViewBase, IResultView
{
    public void SetActive(bool isActivate)
    {
        base.SetActiveCanvasGroup(isActivate);
    }
}
