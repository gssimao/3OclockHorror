using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invController : MonoBehaviour
{
    public Canvas invUI;
    public Camera invCamera;
    public Camera Main;
    public Canvas timeUI;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        invUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            if (!active)
            {
                Main.gameObject.SetActive(false);
                timeUI.gameObject.SetActive(false);
                invCamera.gameObject.SetActive(true);
                invUI.gameObject.SetActive(true);

                active = true;
            }
            else
            {
                Main.gameObject.SetActive(true);
                timeUI.gameObject.SetActive(true);
                invCamera.gameObject.SetActive(false);
                invUI.gameObject.SetActive(false);

                active = false;
            }
        }
    }
}
