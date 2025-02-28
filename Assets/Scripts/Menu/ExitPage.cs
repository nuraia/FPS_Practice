using System;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class ExitPage : Page
{
    public RectTransform exitPanel;
    public float popDuration;
    private Vector3 originalScale;
    void Start()
    {
        originalScale = exitPanel.localScale;
    }

    public void OnClickExit()
    {
        
        exitPanel.DOScale(originalScale, popDuration)
            .SetEase(Ease.OutBack);
    }
    
    public async void OnClickNo()
    {
        exitPanel.DOScale(Vector3.zero, popDuration)
             .SetEase(Ease.InBack);
        await (ExitPanelPopDown());
    }
    async UniTask ExitPanelPopDown()
    {
        await UniTask.Delay(2000);
        
    }

}
