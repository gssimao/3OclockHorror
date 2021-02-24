using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRender : MonoBehaviour
{
    private GameObject item;
    public Sprite sprite;
    private Image image;
    [TextArea]
    public string Note;
    private GameObject NoteText;
    private Sprite transparent;
    public bool active;
    public invInput Listener;
    public workbench_cntrl workbench;
    public bool colliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
        Debug.Log("Entered collider");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Listener.enabled = false;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Listener.enabled = true;
        colliding = false;
        image.sprite = transparent;
    }

    private void Update()
    {
        if (colliding)
        {
            //Input.GetKeyDown(KeyCode.F) &&  
            if (Input.GetKeyDown(KeyCode.F) && !active)
            {
                Debug.Log("key pressed");
                active = true;
                image.sprite = sprite;
                NoteText.SetActive(true);
                NoteText.GetComponent<Text>().text = Note;
                
            }
            //Input.GetKeyDown(KeyCode.F) && 
            else if (Input.GetKeyDown(KeyCode.F) && active)
            {
                NoteText.GetComponent<Text>().text = "";
                NoteText.SetActive(false);
                image.sprite = transparent;
                active = false;
            }
        }
    }

    void Awake()
    {
        active = false;
        colliding = false;
        item = GameObject.Find("Image");
        image = GameObject.Find("PopupImage").GetComponent<Image>();
        NoteText = GameObject.Find("NoteText");
        NoteText.GetComponent<Text>().text = "";
        transparent = image.sprite;
    }
}
