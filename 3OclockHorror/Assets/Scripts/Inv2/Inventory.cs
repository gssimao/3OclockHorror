using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour, IItemContainer
{
    [SerializeField]
    List<Item> items; //Only for starting with items in this inventory. Therefore mostly depreciated.
    [SerializeField] 
    ItemSlot[] itemSlots; //The slots that hold and display items for the inventory.
    [Space]
    [SerializeField]
    Transform itemsParent; //The hirearchy parent to those slots

    [SerializeField]
    bool PInv; //True if this inventory is the player inventory.

    public bool active; //True if this is an active dynamic inventory.
    public event Action<ItemSlot> onPointerEnterEvent; //Event chain holders, for moving / interacting with items in various ways.
    public event Action<ItemSlot> onPointerExitEvent;
    public event Action<ItemSlot> onRightClickEvent;
    public event Action<ItemSlot> onBeginDragEvent;
    public event Action<ItemSlot> onEndDragEvent;
    public event Action<ItemSlot> onDragEvent;
    public event Action<ItemSlot> onDropEvent;

    private void Awake()
    {
        if (itemsParent != null) //If the item parent is not null, get all of the children component item slots, add them to the item slots list. 
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }


        for (int i = 0; i < itemSlots.Length; i++) //Run through the list, adding invokers and setting their Pinv bool to true if this is the player inventory. 
        {
            AddInvokers(itemSlots[i]);
            if (PInv)
            {
                itemSlots[i].PlayerInv = true;
            }
        }

        SetStartingItems();
    }

    //Adding, removing items, changing or setting starting items, etc.
    #region Add/Change Items  
    public void SetStartingItems()
    {
        int i;
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

    public void AddStartingItem(Item item)
    {
        items.Add(item);
    }

    public void InitStartingItems(List<Item> items)
    {
        this.items = items;
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
    #endregion

    //Is the container full, does it contain a specific item, count of items, etc
    #region Query Items
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
    #endregion

    //Opening, closing, and linking dynamic inventories. 
    #region Dynamic Inventories
    //Properly open a dynamic inventory.
    public void OpenInv()
    {
        itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        for (int i = 0; i < itemSlots.Length; i++)
        {
            AddInvokers(itemSlots[i]);
        }
        SetStartingItems();
        active = true;
    }

    //Properly close a dynamic inventory.
    public void CloseInv()
    {
        items.Clear();
        foreach(ItemSlot slot in itemSlots)
        {
            if(slot.Item != null)
            {
                items.Add(slot.Item);
            }
            RemoveInvokers(slot);
        }
        itemSlots = null;
        active = false;
    }

    public void AddInvokers(ItemSlot slot)
    {
        slot.onPointerEnterEvent += onPointerEnterEvent;
        slot.onPointerExitEvent += onPointerExitEvent;
        slot.onRightClickEvent += onRightClickEvent;
        slot.onBeginDragEvent += onBeginDragEvent;
        slot.onEndDragEvent += onEndDragEvent;
        slot.onDragEvent += onDragEvent;
        slot.onDropEvent += onDropEvent;
    }
    public void RemoveInvokers(ItemSlot slot)
    {
        slot.onPointerEnterEvent -= onPointerEnterEvent;
        slot.onPointerExitEvent -= onPointerExitEvent;
        slot.onRightClickEvent -= onRightClickEvent;
        slot.onBeginDragEvent -= onBeginDragEvent;
        slot.onEndDragEvent -= onEndDragEvent;
        slot.onDragEvent -= onDragEvent;
        slot.onDropEvent -= onDropEvent;
    }

    #endregion

    public void SetItemParent(Transform input)
    {
        itemsParent = input;
    }
}
