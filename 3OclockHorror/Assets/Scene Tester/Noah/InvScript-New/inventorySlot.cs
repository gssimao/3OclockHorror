using UnityEngine;
using UnityEngine.UI;

public class inventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;

    public void addItem(Item itemToAdd)
    {
        item = itemToAdd;

        icon.sprite = item.sprite;
        icon.enabled = true;
    }

    public void removeItem()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
