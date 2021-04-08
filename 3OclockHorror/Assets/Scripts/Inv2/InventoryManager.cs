using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;
    [SerializeField]
    Inventory craftInventory;
    [SerializeField]
    ItemTooltip itemTooltip;
    [SerializeField]
    ItemSlot draggableSlot;
    [SerializeField]
    NoteStarter noteStarter;
    [SerializeField]
    PhotoController photoControl;
    [SerializeField]
    journalCntrl Journal;

    public GameObject craftField;

    Inventory workbenchInv;
    ItemSlot orgSlot;
    bool dropped = false;

    UniversalControls uControls;
    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();
        //Add the events to player invenotry and craft inventory as these are static. Workbench inventory will be dynamic and thus is not set.
        AddEvents(inventory);
        AddEvents(craftInventory);
    }

    private void OnDisable()
    {
        uControls.Disable();
    }

    private void Start()
    {
        //noteStarter.initNotePuzzle();
    }

    //Sets all inventory event references for the given inventory.
    private void AddEvents(Inventory inv)
    {
        //Pointer Enters/Exits the slot
        inv.onPointerEnterEvent += ShowTooltip;
        inv.onPointerExitEvent += HideTooltip;
        //A drag event is initiated or ended 
        inv.onBeginDragEvent += BeginDrag;
        inv.onEndDragEvent += EndDrag;
        //Ongoing drag and drops
        inv.onDragEvent += Drag;
        inv.onDropEvent += Drop;
    }
    private void RemoveEvents(Inventory inv)
    {
        //Pointer Enters/Exits the slot
        inv.onPointerEnterEvent -= ShowTooltip;
        inv.onPointerExitEvent -= HideTooltip;
        //A drag event is initiated or ended 
        inv.onBeginDragEvent -= BeginDrag;
        inv.onEndDragEvent -= EndDrag;
        //Ongoing drag and drops
        inv.onDragEvent -= Drag;
        inv.onDropEvent -= Drop;
    }

    public void ActivateInventory(Inventory inv)
    {
        workbenchInv = inv;
        AddEvents(workbenchInv);
    }
    public void DeactivateInventory(Inventory inv)
    {
        inv.CloseInv();
        workbenchInv = null;
        RemoveEvents(inv);
    }

    #region Event Functions
    private void ShowTooltip(ItemSlot slot)
    {
        if (slot.Item != null)
        {
            itemTooltip.ShowTooltip(slot.Item);
        }
    }

    private void HideTooltip(ItemSlot slot)
    {
        itemTooltip.HideTooltip();
    }

    private void BeginDrag(ItemSlot slot)
    {
        if(slot.Item != null)
        {
            draggableSlot.Item = slot.Item;
            draggableSlot.transform.position = Input.mousePosition; /*new Vector3( uControls.UI.CursorPosition.ReadValue<Vector2>().x,
                                                            uControls.UI.CursorPosition.ReadValue<Vector2>().y,
                                                            0);*/ 
            draggableSlot.gameObject.SetActive(true);
            orgSlot = slot;
            slot.Item = null;
            dropped = false;
        }
        else if(slot.Item == null)
        {
            draggableSlot.gameObject.SetActive(false);
        }
    }

    private void EndDrag(ItemSlot slot)
    {
        if (!dropped && draggableSlot.Item != null)
        {
            orgSlot.Item = draggableSlot.Item;
        }

        draggableSlot.Item = null;
        draggableSlot.gameObject.SetActive(false);
    }

    private void Drag(ItemSlot slot)
    {
        if (draggableSlot.gameObject.activeSelf)
        {
            draggableSlot.transform.position = Input.mousePosition;/*new Vector3( uControls.UI.CursorPosition.ReadValue<Vector2>().x, 
                                                            uControls.UI.CursorPosition.ReadValue<Vector2>().y,
                                                            0);*/ 
        }
    }

    private void Drop(ItemSlot dropItemSlot)
    {
        if (draggableSlot.Item != null)
        {
            if (dropItemSlot.CanRecieveItem(draggableSlot.Item) && orgSlot.CanRecieveItem(dropItemSlot.Item))
            {
                Item draggedItem = draggableSlot.Item;
                orgSlot.Item = dropItemSlot.Item;
                dropItemSlot.Item = draggedItem;

                dropped = true;

                if (draggedItem.Note && dropItemSlot.PlayerInv && !draggedItem.isRead)
                {
                    /*
                    if (draggedItem.RusselNote)
                    {
                        if (draggedItem.nextNote != null)
                        {
                            noteStarter.SetNextNoteInventory(draggedItem);
                        }
                        draggedItem.isRead = true;

                    }
                    */
                    Journal.AddNote(draggedItem);

                    dropItemSlot.Item = null;
                }
                else if (draggedItem.photo && !photoControl.Distributed)
                {
                    photoControl.DistPhotos();
                }
            }
        }
    }
    #endregion
}
