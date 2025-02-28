using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPageManager : MonoBehaviour
{
    public List<Page> Pages = new();
    public Page currentPage;
   
    void Start()
    {
        ShowPage("MainPage");
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
                //Debug.Log("match");
                p.PageOpen();
                currentPage = p;
                break;
            }
        }

    }

   
}
