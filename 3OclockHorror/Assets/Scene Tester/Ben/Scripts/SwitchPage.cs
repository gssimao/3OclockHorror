using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPage : MonoBehaviour
{
    public RectTransform[] Pages = new RectTransform[3];

    RectTransform[] Buttons = new RectTransform[3];


    // Start is called before the first frame update
    void Start()
    {
        Buttons[0] = Pages[0].GetComponentInChildren<RectTransform>();
        Buttons[1] = Pages[1].GetComponentInChildren<RectTransform>();
        Buttons[2] = Pages[2].GetComponentInChildren<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangePage(int page)
    {
        if (page == 0)
        {
            
        }
        else if (page == 1)
        {

        }
        else if (page == 2)
        {
            Buttons[page].anchoredPosition3D = new Vector3(Mathf.Abs(Buttons[page].anchoredPosition3D.x), Buttons[page].anchoredPosition3D.y, Buttons[page].anchoredPosition3D.x);
            Pages[page].anchoredPosition3D = new Vector3(Pages[page].anchoredPosition3D.x, Pages[page].anchoredPosition3D.y, -35.0f);
        }
    }
}
