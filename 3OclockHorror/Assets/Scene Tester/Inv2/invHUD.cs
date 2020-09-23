using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invHUD : MonoBehaviour
{
    public inventory pInv;

    // Start is called before the first frame update
    void Start()
    {
        pInv.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform invPanel = transform.Find("PlayerInvSlots");
        foreach(Transform slot in invPanel)
        {
            Transform imageTransform = slot.GetChild(0);
            Image image = slot.GetChild(0).GetComponent<Image>();
            itemDragHandler itemDragHandler = imageTransform.GetComponent<itemDragHandler>();

            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.image;

                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }
    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform invPanel = transform.Find("PlayerInvSlots");
        foreach (Transform slot in invPanel)
        {
            Transform imageTransform = slot.GetChild(0);
            Image image = slot.GetChild(0).GetComponent<Image>();
            itemDragHandler itemDragHandler = imageTransform.GetComponent<itemDragHandler>();

            if (itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
