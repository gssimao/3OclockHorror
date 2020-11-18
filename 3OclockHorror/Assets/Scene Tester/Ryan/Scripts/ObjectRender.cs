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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        image.sprite = sprite;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        image.sprite = transparent;
    }

    void Start()
    {
        item = GameObject.Find("Image");
        image = GameObject.Find("PopupImage").GetComponent<Image>();
        transparent = image.sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
