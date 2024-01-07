using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultView : ViewBase, IResultView
{
    [SerializeField] private RectTransform hujisan;
    [SerializeField] private TMP_Text cntText;

    public void SetActive(bool isActivate)
    {
        base.SetActiveCanvasGroup(isActivate);
        hujisan.DOLocalMoveY(0,3);
    }

    public void ApplyCount(int value) => cntText.text = $"パワー\n{value}";
}
