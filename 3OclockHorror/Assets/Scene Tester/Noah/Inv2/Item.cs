using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items", order = 1)]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;

    public bool rand;
    public string desc;
}
