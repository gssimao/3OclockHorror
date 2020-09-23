using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemClickHandler : MonoBehaviour
{
    public void OnItemClicked()
    {
        itemDragHandler handler = gameObject.transform.Find("itemImage").GetComponent<itemDragHandler>();
        IInventoryItem item = handler.Item;

        item.OnUse();
    }
}
