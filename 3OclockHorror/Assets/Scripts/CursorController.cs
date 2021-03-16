using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public Texture2D cursorArrow;
    public Texture2D cursorDown;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if(!Cursor.visible)
        {
            Cursor.visible = true;
        }
        //Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = cursorPos;
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorDown, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.Auto);
    }
}
