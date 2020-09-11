using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invUI : MonoBehaviour
{
    public Canvas myUI;
    public Camera invCamera;
    public Camera Main;
    public Canvas timeUI;
    public GameObject workbenchInv;
    public GameObject puzzleUI;
    public GameObject slotParent;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        myUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            if(!active)
            {
                activateUI();
            }
            else
            {
                deactivateUI();
            }
        }
    }

    public void activateUI()
    {
        Main.gameObject.SetActive(false);
        timeUI.gameObject.SetActive(false);
        invCamera.gameObject.SetActive(true);
        myUI.gameObject.SetActive(true);
        workbenchInv.SetActive(false);
        puzzleUI.SetActive(false);
        slotParent.SetActive(true);

        active = true;
    }
    public void deactivateUI()
    {
        Main.gameObject.SetActive(true);
        timeUI.gameObject.SetActive(true);
        invCamera.gameObject.SetActive(false);
        myUI.gameObject.SetActive(false);

        active = false;
    }
}
