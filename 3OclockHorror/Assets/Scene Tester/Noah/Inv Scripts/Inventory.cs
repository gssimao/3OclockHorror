using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public const int numItemSlots = 4; //Per instance code for controlling number of items attached.
    public Image[] itemImages = new Image[numItemSlots]; //Arrays to hold items and item images
    public Item[] items = new Item[numItemSlots];

    void Awake()
    {
        for(int i = 0; i < numItemSlots; i++) //Init inventory and make sure everything is properly set to null
        {
            itemImages[i] = null;
            items[i] = null;
        }
    }

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }
    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }
}