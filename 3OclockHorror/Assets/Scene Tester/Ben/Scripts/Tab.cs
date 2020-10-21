using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [SerializeField]
    GameObject itemSlotsGrid;

    ItemSlot[] itemSlots;
    Item[] invItems;

    #region Get/Set

    public Item[] getItems()
    {
        itemSlots = itemSlotsGrid.GetComponentsInChildren<ItemSlot>();
        for (int i = 0; i < itemSlots.Length; i++)
        {
            invItems[i] = itemSlots[i].Item;
        }

        return invItems;
    }

    #endregion
}
