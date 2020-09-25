using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;
    [SerializeField]
    Inventory craftinventory;
    [SerializeField]
    ItemTooltip itemTooltip;
    [SerializeField]
    Image draggableItem;

    private ItemSlot draggedSlot;

    private void Awake()
    {
        //Ex for transfer on right click
        //inventory.onItemRightClickedEvent += equipFromInventory;

        //Set up events
        //Right click:

        //Pointer Enter/Exit:
        inventory.onPointerEnterEvent += ShowTooltip;
        inventory.onPointerExitEvent += HideTooltip;
        craftinventory.onPointerEnterEvent += ShowTooltip;
        craftinventory.onPointerExitEvent += HideTooltip;

        //Drag Handlers:
        inventory.onBeginDragEvent += BeginDrag;
        inventory.onEndDragEvent += EndDrag;
        craftinventory.onBeginDragEvent += BeginDrag;
        craftinventory.onEndDragEvent += EndDrag;

        //Drag/Drop handlers:
        inventory.onDragEvent += Drag;
        inventory.onDropEvent += Drop;
        craftinventory.onDragEvent += Drag;
        craftinventory.onDropEvent += Drop;
    }


    private void ShowTooltip(ItemSlot slot)
    {
        if (slot.item != null)
        {
            itemTooltip.ShowTooltip(slot.item);
        }
    }

    private void HideTooltip(ItemSlot slot)
    {
        itemTooltip.HideTooltip();
    }

    private void BeginDrag(ItemSlot slot)
    {
        if(slot.item != null)
        {
            draggedSlot = slot;
            draggableItem.sprite = slot.item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void EndDrag(ItemSlot slot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(ItemSlot slot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop(ItemSlot dropItemSlot)
    {
        if (dropItemSlot.CanRecieveItem(draggedSlot.item) && draggedSlot.CanRecieveItem(dropItemSlot.item))
        {
            Item draggedItem = draggedSlot.item;
            draggedSlot.item = dropItemSlot.item;
            dropItemSlot.item = draggedItem;
        }
    }
}
