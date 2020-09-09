using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance; //This specific inventory. Will need to be adjusted eventually
    public List<ItemMover> items; //List of items - size is managed by editor. This allows dynamic per instance sizes without complicated stuff.
    public inventorySlot[] slots; //List of slots
    public Transform itemsParent; //The parent from which we get the number of slots.

    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;

    void Awake() //Some stuff here will need to be removed - eventually multiple inventories will exist, meaning the first chunk is unnecessary
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

    
    public void AddItem(ItemMover itemToAdd, int slotNum) //Adds an item in to the inventory.
    {
        if(!slots[slotNum].inUse && items[slotNum] == null) //Checks if the slot we want to use is empty, if yes then just place it. Other states will be needed.
        {
            items[slotNum] = itemToAdd;
            slots[slotNum].inUse = true;
        }
        else if(slots[slotNum].inUse && items[slotNum] != null)
        {
            items[slotNum].grabSet(true);
            items[slotNum] = itemToAdd;
            slots[slotNum].inUse = true;
        }
    }
    public void RemoveItem(ItemMover itemToRemove, int slotNum) //Removes an item from the list
    {
        if(slots[slotNum].inUse && items[slotNum] != null) //Grabs the item out of the slot and removes it.
        {
            items[slotNum] = null;
            slots[slotNum].inUse = false;
        }
    }
}
