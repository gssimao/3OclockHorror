using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invInput : MonoBehaviour
{

    [SerializeField]
    KeyCode invKey;
    [SerializeField]
    GameObject invCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(invKey))
        {
            if (invCanvas.activeSelf)
            {
                invCanvas.SetActive(false);
            }
            else
            {
                invCanvas.SetActive(true);
            }
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
