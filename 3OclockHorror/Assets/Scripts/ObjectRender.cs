using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRender : MonoBehaviour
{
    private GameObject item;
    public Sprite sprite;
    private Image image;
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
        //Debug.Log("In Collider");
        if (Input.GetKeyDown(KeyCode.E) && !active)
        {
            Debug.Log("Key pressed");
            image.sprite = sprite;
            active = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && active)
        {
            image.sprite = transparent;
            active = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Listener.enabled = true;
        colliding = false;
        image.sprite = transparent;
    }

    void Start()
    {
        active = false;
        colliding = false;
        item = GameObject.Find("Image");
        image = GameObject.Find("PopupImage").GetComponent<Image>();
        transparent = image.sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
