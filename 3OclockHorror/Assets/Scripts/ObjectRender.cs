using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRender : MonoBehaviour
{
    public Sprite sprite;
    private Image image;
    [TextArea]
    public string Note;
    private GameObject NoteText;
    private Sprite transparent;
    public bool active;
    public invInput Listener;
    public bool colliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        image.sprite = sprite;
        NoteText.SetActive(true);
        NoteText.GetComponent<Text>().text = Note;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        image.sprite = transparent;
        NoteText.GetComponent<Text>().text = "";
        NoteText.SetActive(false);
        image.sprite = transparent;
        active = false;
    }

    void Awake()
    {
        active = false;
        colliding = false;
        image = GameObject.Find("PopupImage").GetComponent<Image>();
        NoteText = GameObject.Find("NoteText");
        NoteText.GetComponent<Text>().text = "";
        transparent = image.sprite;
    }
}
