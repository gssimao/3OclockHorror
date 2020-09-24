using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;

    private void Awake()
    {
        //Ex for transfer on right click
        //inventory.onItemRightClickedEvent += equipFromInventory;
    }
    /*
     * example to transfer from one inv to another
     * private void equipFromInventory(Item item)
     * {
            if(item is EquipableItem)
            {
                Equip((EquipableItem)item);
            }
        }
     */
}
