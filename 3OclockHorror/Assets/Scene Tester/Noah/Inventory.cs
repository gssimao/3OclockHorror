using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public Image[] itemImages; //Arrays to hold items and item images
    public List<Item> items; //List of items - size is managed by editor. This allows dynamic per instance sizes without complicated stuff.

    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;

    void Awake()
    {
        instance = this;
    }

    
    public void AddItem(Item itemToAdd)
    {
        items.Add(itemToAdd);
        onItemChangedCallback.Invoke();
    }
    public void RemoveItem(Item itemToRemove)
    {
        items.Remove(itemToRemove);
    }
    
}
