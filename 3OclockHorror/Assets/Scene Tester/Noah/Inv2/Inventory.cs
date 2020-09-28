using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour, IItemContainer
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
            itemSlots[i].onPointerEnterEvent += slot => onPointerEnterEvent(slot);
            itemSlots[i].onPointerExitEvent += slot => onPointerExitEvent(slot);
            itemSlots[i].onRightClickEvent += slot => onRightClickEvent(slot);
            itemSlots[i].onBeginDragEvent += slot => onBeginDragEvent(slot);
            itemSlots[i].onEndDragEvent += slot => onEndDragEvent(slot);
            itemSlots[i].onDragEvent += slot => onDragEvent(slot);
            itemSlots[i].onDropEvent += slot => onDropEvent(slot);
        }
        SetStartingItems();
    }

    public void SetStartingItems()
    {
        int i = 0;
        for(i = 0; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }
        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }


    public bool AddItem(Item item)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;
                return true;
            }
        }
        return false;
    }
    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }


    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                return true;
            }
        }
        return false;
    }

    public int CountItems(Item item)
    {
        int c = 0;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                c++;
            }
        }
        return c;
    }
    public void CloseInv()
    {
        items.Clear();
        foreach(ItemSlot slot in itemSlots)
        {
            if(slot.Item != null)
            {
                items.Add(slot.Item);
            }
        }
    }
}
