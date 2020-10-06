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
}
