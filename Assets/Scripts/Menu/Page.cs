using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DG.Tweening;
using System;

public class Page  :MonoBehaviour
{
    public string pageName;
    public RectTransform mainSection;
    public CanvasGroup canvasGroup;
    public float fadeTime;
    public void PageClose()
    {
        canvasGroup.DOFade(0, fadeTime);
    }

    public void PageOpen()
    {
        canvasGroup.DOFade(1, fadeTime);
    }
}
