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
    [SerializeField]
    public bool active;
    private clockCntrl clockctrl;
    public invInput Listener;
    [SerializeField]
    private bool colliding;

    UniversalControls uControls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colliding = false;
        }
    }

    void Awake()
    {
        clockctrl = GameObject.Find("Player2").GetComponent<clockCntrl>();
        uControls = new UniversalControls();
        uControls.Enable();
        active = false;
        colliding = false;
        image = GameObject.Find("PopupImage").GetComponent<Image>();
        NoteText = GameObject.Find("NoteText");
        NoteText.GetComponent<Text>().text = "";
        transparent = image.sprite;
    }
    private void OnDisable()
    {
        uControls.Disable();
    }
    private void Update()
    {
        if(uControls.Player.Interact.triggered && colliding && !active)
        {
            active = true;
            image.sprite = sprite;
            NoteText.SetActive(true);
            NoteText.GetComponent<Text>().text = Note;
            clockctrl.pause = true;
            Debug.Log("triggered");
        }
        if (uControls.Player.Interact.triggered && colliding && active)
        {
            image.sprite = transparent;
            NoteText.GetComponent<Text>().text = "";
            NoteText.SetActive(false);
            image.sprite = transparent;
            clockctrl.pause = false;
            active = false;
        }
    }
}
