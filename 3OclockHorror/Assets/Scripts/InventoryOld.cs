/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOld : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;

    private void Start()
    {
        GiveItem("Test Object");
        //RemoveItem("Test Object");
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        Debug.Log("Added Item: " + itemToAdd.title);
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public Item CheckForItem(string itemName)
    {
        return characterItems.Find(item => item.title == itemName);
    }

    public void RemoveItem(int id)
    {
        Item item = CheckForItem(id);
        if(item != null)
        {
            characterItems.Remove(item);
            Debug.Log("Item Removed: " + item.title);
        }
    }

    public void RemoveItem(string itemName)
    {
        Item item = CheckForItem(itemName);
        if(item != null)
        {
            characterItems.Remove(item);
            Debug.Log("Item Removed: " + item.title);
        }
    }
}*/
