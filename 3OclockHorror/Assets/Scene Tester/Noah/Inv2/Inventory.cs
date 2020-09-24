﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> items;
    [SerializeField]
    ItemSlot[] itemSlots;
    [Space]
    [SerializeField]
    Transform itemsParent;

    public event Action<Item> onItemRightClickedEvent;

    private void Awake()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].onRightClickEvent += onItemRightClickedEvent;
        }
    }

    private void OnValidate()
    {
        if(itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

    public void RefreshUI()
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
        if (IsFull())
            return false;
        items.Add(item);
        RefreshUI();
        return true;
    }
    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }


    public bool IsFull()
    {
        if(items.Count >= itemSlots.Length)
        {
            return true;
        }
        return false;
    }
}
