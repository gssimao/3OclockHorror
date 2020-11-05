using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invInput : MonoBehaviour
{

    [SerializeField]
    KeyCode invKey;
    [SerializeField]
    GameObject Journal;
    [SerializeField]
    GameObject invCanvas;
    [SerializeField]
    GameObject tooltip;
    [SerializeField]
    InputField jInput;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(invKey) && !jInput.isFocused)
        {
            if (Journal.activeSelf)
            {
                Journal.SetActive(false);
            }
            else
            {
                Journal.SetActive(true);
            }

            /*
            if (invCanvas.activeSelf)
            {
                tooltip.SetActive(false);
                invCanvas.SetActive(false);
            }
            else
            {
                invCanvas.SetActive(true);
            }
            */
        }
    }

    /*
    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    */
}
