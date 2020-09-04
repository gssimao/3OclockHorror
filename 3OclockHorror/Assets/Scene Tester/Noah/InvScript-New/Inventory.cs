using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items; //List of items - size is managed by editor. This allows dynamic per instance sizes without complicated stuff.
    public inventorySlot[] slots; //List of slots
    public Transform itemsParent;

    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one Inventory");
        }
        else
        {
            instance = this;
        }

        slots = itemsParent.GetComponentsInChildren<inventorySlot>();

        if(slots.Length != items.Count)
        {
            Debug.LogError("Slots / Items count differs");
        }
    }

    
    public void AddItem(Item itemToAdd)
    {
        if(items[0] == null)
        {
            items[0] = itemToAdd;
        }
    }
    public void RemoveItem(Item itemToRemove)
    {
        if (items[0] != null)
        {
            items[0] = null;
        }
    }   
}
