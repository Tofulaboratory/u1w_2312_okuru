using System;
using UniRx;

public interface IResultView
{
    public void SetActive(bool isActivate);
    public void ApplyCount(int value);
}
