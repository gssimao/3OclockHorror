﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class journalCntrl : MonoBehaviour
{
    public List<page> Pages;
    public int curPage = 0;
    public GameObject pagePrefab;
    public Canvas Journal;

    public void CreatePage()
    {
        GameObject Page = Instantiate(pagePrefab, pagePrefab.transform.position, pagePrefab.transform.rotation);
        Page.transform.SetParent(Journal.transform);
        ResetRectTransform(Page, pagePrefab);
        page newPage = Page.GetComponent<page>();

        newPage.left.text = "";
        newPage.right.text = "";
        newPage.prevPage = Pages[curPage].gameObject;
        Pages[curPage].nextPage = newPage.gameObject;
        Pages[curPage].ActivateNextButton();

        Pages.Add(newPage);

        curPage++;
    }

    public void AddNote(Item note)
    {
        Debug.Log("Adding notes");
        if(Pages[curPage].left.text == "")
        {
            Pages[curPage].left.text = note.desc;
        }
        else if(Pages[curPage].right.text == "")
        {
            Pages[curPage].right.text = note.desc;
        }
        else
        {
            CreatePage();
            Pages[curPage].left.text = note.text;
        }
    }

    public void ResetRectTransform(GameObject newPage, GameObject pagePrefab)
    {
        RectTransform newP = newPage.GetComponent<RectTransform>();
        RectTransform prefab = pagePrefab.GetComponent<RectTransform>();

        newP.sizeDelta = prefab.sizeDelta;
        newP.anchoredPosition = prefab.anchoredPosition;
        newP.anchorMin = prefab.anchorMin;
        newP.transform.localScale = prefab.transform.localScale;
    }
}
