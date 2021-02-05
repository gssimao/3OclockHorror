using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPage : MonoBehaviour
{
    public RectTransform[] Pages = new RectTransform[3];

    public RectTransform[] Buttons = new RectTransform[3];


    // Start is called before the first frame update
    void Start()
    {
        Buttons[0] = Pages[0].GetComponentInChildren<Button>().GetComponent<RectTransform>(); //Back Page
        Buttons[1] = Pages[1].GetComponentInChildren<Button>().GetComponent<RectTransform>(); //Middle Page
        Buttons[2] = Pages[2].GetComponentInChildren<Button>().GetComponent<RectTransform>(); //Front page


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePage(int page)
    {
        if (page == 0)//Back page
        {
            Buttons[1].anchoredPosition3D = new Vector3(Mathf.Abs(Buttons[1].anchoredPosition3D.x), Buttons[1].anchoredPosition3D.y, Buttons[1].anchoredPosition3D.z);
            Buttons[1].eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
            Buttons[2].anchoredPosition3D = new Vector3(Mathf.Abs(Buttons[2].anchoredPosition3D.x), Buttons[2].anchoredPosition3D.y, Buttons[2].anchoredPosition3D.z);
            Buttons[2].eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);

            Pages[1].anchoredPosition3D = new Vector3(Pages[1].anchoredPosition3D.x, Pages[1].anchoredPosition3D.y, 5.0f);
            Pages[2].anchoredPosition3D = new Vector3(Pages[2].anchoredPosition3D.x, Pages[2].anchoredPosition3D.y, 0.0f);

            Pages[0].anchoredPosition3D = new Vector3(Pages[0].anchoredPosition3D.x, Pages[0].anchoredPosition3D.y, 10.0f);
        }
        else if (page == 1)//Middle Page
        {
            Buttons[1].anchoredPosition3D = new Vector3(-1 * Mathf.Abs(Buttons[1].anchoredPosition3D.x), Buttons[1].anchoredPosition3D.y, Buttons[1].anchoredPosition3D.z);
            Buttons[1].eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            Buttons[2].anchoredPosition3D = new Vector3(Mathf.Abs(Buttons[2].anchoredPosition3D.x), Buttons[2].anchoredPosition3D.y, Buttons[2].anchoredPosition3D.z);
            Buttons[2].eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);

            Pages[0].anchoredPosition3D = new Vector3(Pages[0].anchoredPosition3D.x, Pages[0].anchoredPosition3D.y, 0.0f);
            Pages[2].anchoredPosition3D = new Vector3(Pages[2].anchoredPosition3D.x, Pages[2].anchoredPosition3D.y, 0.0f);

            Pages[1].anchoredPosition3D = new Vector3(Pages[1].anchoredPosition3D.x, Pages[1].anchoredPosition3D.y, 10.0f);
        }
        else if (page == 2)//Front Page
        {
            Buttons[1].anchoredPosition3D = new Vector3(-1 * Mathf.Abs(Buttons[1].anchoredPosition3D.x), Buttons[1].anchoredPosition3D.y, Buttons[1].anchoredPosition3D.z);
            Buttons[1].eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            Buttons[2].anchoredPosition3D = new Vector3(-1 * Mathf.Abs(Buttons[2].anchoredPosition3D.x), Buttons[2].anchoredPosition3D.y, Buttons[2].anchoredPosition3D.z);
            Buttons[2].eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);

            Pages[0].anchoredPosition3D = new Vector3(Pages[0].anchoredPosition3D.x, Pages[0].anchoredPosition3D.y, 0.0f);
            Pages[1].anchoredPosition3D = new Vector3(Pages[1].anchoredPosition3D.x, Pages[1].anchoredPosition3D.y, 0.0f);

            Pages[2].anchoredPosition3D = new Vector3(Pages[2].anchoredPosition3D.x, Pages[2].anchoredPosition3D.y, 10.0f);
        }
    }
}
