using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> items; //Only for starting with items in this inventory. Therefore mostly depreciated.
    [SerializeField]
    ItemSlot[] itemSlots;
    [Space]
    [SerializeField]
    Transform itemsParent;

    public event Action<ItemSlot> onPointerEnterEvent;
    public event Action<ItemSlot> onPointerExitEvent;
    public event Action<ItemSlot> onRightClickEvent;
    public event Action<ItemSlot> onBeginDragEvent;
    public event Action<ItemSlot> onEndDragEvent;
    public event Action<ItemSlot> onDragEvent;
    public event Action<ItemSlot> onDropEvent;

    private void Awake()
    {

        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].onPointerEnterEvent += onPointerEnterEvent;
            itemSlots[i].onPointerEnterEvent += onPointerExitEvent;
            itemSlots[i].onRightClickEvent += onRightClickEvent;
            itemSlots[i].onBeginDragEvent += onBeginDragEvent;
            itemSlots[i].onEndDragEvent += onEndDragEvent;
            itemSlots[i].onDragEvent += onDragEvent;
            itemSlots[i].onDropEvent += onDropEvent;
        }
        SetStartingItems();
    }

    public void SetStartingItems()
    {
        int i = 0;
        for(i = 0; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].item = items[i];
        }
        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].item = null;
        }
    }


    public bool AddItem(Item item)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].item == null)
            {
                itemSlots[i].item = item;
                return true;
            }
        }
        return false;
    }
    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == item)
            {
                itemSlots[i].item = null;
                return true;
            }
        }
        return false;
    }


    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                return false;
            }
        }
        return true;
    }
}
