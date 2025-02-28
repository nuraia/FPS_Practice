using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPageManager : MonoBehaviour
{
    [SerializeField]private List<Page> Pages = new();
    private Dictionary<string, Page> pageDictionary = new Dictionary<string, Page>();
    public Page currentPage;
   
    void Start()
    {
        ShowPage("MainPage");
        InitializePages();
    }
    private void InitializePages()
    {
    }

    public void ShowPage(string pageName)
    {
        if (currentPage != null)
        {
            currentPage.PageClose();
        }
       
        foreach (Page p in Pages)
        {

            if (p.pageName == pageName)
            {
                Debug.Log("match");
                p.PageOpen();
                currentPage = p;
                break;
            }
        }

    }

   
}
