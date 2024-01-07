using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IngameView : ViewBase, IIngameView
{
    [SerializeField] private SantaUnit santaUnit;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PresentUnit presentUnit;
    [SerializeField] private EarthUnit earthUnit;
    [SerializeField] private TMP_Text desText;
    [SerializeField] private TMP_Text cntText;
    [SerializeField] private TMP_Text timerText;

    private Subject<bool> _onThrow = new();
    public IObserver<bool> OnThrow() => _onThrow;

    private float preFontSize = 0;

    public void Initialize()
    {
        cameraController.Apply();
        santaUnit.Apply();

        _onThrow.Subscribe(async _ =>
        {
            int duration = 3;
            presentUnit.MoveToGoalAsync(duration).Forget();
            cameraController.SetLookAt(presentUnit.transform);
            cameraController.SetWidth(500);

            await UniTask.Delay(1000 * duration);
            earthUnit.Explode();
            AudioManager.Instance.PlaySE("Exp");
        }).AddTo(this);

        preFontSize = cntText.fontSize;
    }

    private void PopText(TMP_Text text)
    {
        var seq = DOTween
        .Sequence()
        .PrependCallback(() => text.fontSize = preFontSize * 0.8f)
        .Append(
            DOTween.To(() => text.fontSize, (value) => text.fontSize = value, preFontSize, 0.2f).SetEase(Ease.InOutSine)
            );
    }

    public void ApplyCount(int value)
    {
        cntText.text = $"パワー\n{value}";
        PopText(cntText);
    }

    public void ApplyTime(int value) => timerText.text = $"{value}";
    public void SetActiveText(bool isActivate)
    {
        cntText.gameObject.SetActive(isActivate);
        timerText.gameObject.SetActive(isActivate);
        desText.gameObject.SetActive(isActivate);
    }

    public void SetActive(bool isActivate)
    {
        base.SetActiveCanvasGroup(isActivate);
    }
}