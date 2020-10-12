using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items", order = 1)]
public class Item : ScriptableObject
{
    //Name, icon, and descriptions
    public string ItemName; //Name of the Item
    public Sprite Icon; //The Item Icon
    public string desc; //A description of what the item is

    //Location Variables
    public bool rand;

    //Some specific stuff for different types of items
    #region Note
    [SerializeField]
    Item Key;

    public Inventory myInv;
    public bool Note;
    public bool isRead = false;
    public Item nextNote;

    public void NextNoteInit() 
    {
        if (nextNote != null)
        {
            desc = desc.Replace("***", nextNote.myInv.name);
            if(nextNote.myInv == null)
            {
                Debug.LogError("No inventory to init to : " + nextNote.ItemName);
            }
            else 
            {
                nextNote.myInv.AddStartingItem(nextNote);
            }
            
        }
    }

    #endregion
}
