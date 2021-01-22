using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    //UIs where cursor should appear
    public List<GameObject> UIs;

    // Start is called before the first frame update
    void Start()
    {
        if(UIs == null)
        {
            Debug.LogError("Mouse cursor control missing one or more UIs for mouse.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool cursorActive = false;
        foreach (GameObject obj in UIs)
        {
            if (obj.activeSelf)
            {
                cursorActive = true;
            }
        }
        if (!cursorActive)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
