using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRender : MonoBehaviour
{
    private GameObject item;
    public Sprite sprite;
    private Image image;
    private PlayerMovement Player;
    [TextArea]
    public string Note;
    private GameObject NoteText;
    private Sprite transparent;
    public bool active;
    public invInput Listener;
    public bool colliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Listener.enabled = false;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Listener.enabled = true;
        colliding = false;
        image.sprite = transparent;
    }

    private void Update()
    {
        if (colliding)
        {
            if (Input.GetKeyDown(KeyCode.F) && !active)
            {
                active = true;
                Player.enabled = false;
                image.sprite = sprite;
                NoteText.SetActive(true);
                NoteText.GetComponent<Text>().text = Note;
                
            }
            else if (Input.GetKeyDown(KeyCode.F) && active)
            {
                NoteText.GetComponent<Text>().text = "";
                NoteText.SetActive(false);
                image.sprite = transparent;
                Player.enabled = true;
                active = false;
            }
        }
    }

    void Awake()
    {
        active = false;
        colliding = false;
        Player = GameObject.Find("Player2").GetComponent<PlayerMovement>();
        item = GameObject.Find("Image");
        image = GameObject.Find("PopupImage").GetComponent<Image>();
        NoteText = GameObject.Find("NoteText");
        NoteText.GetComponent<Text>().text = "";
        transparent = image.sprite;
    }
}
