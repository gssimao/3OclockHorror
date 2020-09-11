using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Item inventory stuff
    public static Inventory instance; //This specific inventory. Will need to be adjusted eventually
    public List<ItemMover> items; //List of items - size is managed by editor. This allows dynamic per instance sizes without complicated stuff.
    public List<ItemMover> workbenchItems;

    //Slot related variables
    public GameObject itemsParent; //The parent from which we get the number of slots.
    public inventorySlot[] slots; //List of slots
    public GameObject workbenchParent;
    public inventorySlot[] workbenchSlots;

    //Workbench puzzle stuff - Most of this is a temporarily rigged solution to work for demo one. None is a permanent solution.
    public ItemMover item1;
    public ItemMover item2;
    public ItemMover item3;
    public GameObject puzzleCanvas;

    void Awake() //Some stuff here will need to be removed - eventually multiple inventories will exist, meaning the first chunk is unnecessary
    {
        instance = this;

        slots = itemsParent.GetComponentsInChildren<inventorySlot>();
        workbenchSlots = workbenchParent.GetComponentsInChildren<inventorySlot>();

        /*
        if(slots.Length != items.Count)
        {
            Debug.LogError("Slots / Items count differs");
        }
        */
    }

    
    public void AddItem(ItemMover itemToAdd, List<ItemMover> itemList, inventorySlot[] slots, int slotNum) //Adds an item in to the inventory.
    {
        if(!slots[slotNum].inUse && itemList[slotNum] == null) //Checks if the slot we want to use is empty, if yes then just place it. Other states will be needed.
        {
            itemList[slotNum] = itemToAdd;
            slots[slotNum].inUse = true;
        }
        else if(slots[slotNum].inUse && items[slotNum] != null)
        {
            itemList[slotNum].grabSet(true);
            itemList[slotNum] = itemToAdd;
            slots[slotNum].inUse = true;
        }

        if(itemList == workbenchItems)
        {
            openPuzzleUI();
        }
    }
    public void RemoveItem(ItemMover itemToRemove, List<ItemMover> itemList, inventorySlot[] slots, int slotNum) //Removes an item from the list
    {
        if(slots[slotNum].inUse && itemList[slotNum] != null) //Grabs the item out of the slot and removes it.
        {
            itemList[slotNum] = null;
            slots[slotNum].inUse = false;
        }
    }

    public void openPuzzleUI()
    {
        bool open = true;
        foreach(ItemMover item in workbenchItems)
        {
            if(item == item1 || item == item2 || item == item3)
            {
                open = true;
            }
            else
            {
                open = false;
                break;
            }
        }
        if(open)
        {
            puzzleCanvas.gameObject.SetActive(true);
            workbenchParent.SetActive(false);
            itemsParent.SetActive(false);
            foreach(ItemMover item in items)
            {
                if (item != null)
                {
                    item.gameObject.SetActive(false);
                }
            }
            foreach (ItemMover item in workbenchItems)
            {
                if (item != null)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }

}
