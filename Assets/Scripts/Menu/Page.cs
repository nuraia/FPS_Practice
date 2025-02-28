using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DG.Tweening;
using System;

public class Page : MonoBehaviour  
{
    [Header("Page Settings")]
    public string pageName;
    [SerializeField] protected float fadeTime;

    protected CanvasGroup canvasGroup;

    protected virtual void Awake()
    {
        InitializeComponents();
    }
    protected virtual void InitializeComponents()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
   
    public async void PageClose()
    {
        canvasGroup.DOFade(0, fadeTime).SetUpdate(true);
        //await canvasGroup.DOFade(0, fadeTime).AsyncWaitForCompletion();
    }

    public async void PageOpen()
    {
        canvasGroup.DOFade(1, fadeTime).SetUpdate(true);
        //await canvasGroup.DOFade(0, fadeTime).AsyncWaitForCompletion();
    }
}
