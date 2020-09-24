using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Image image;
    [SerializeField]
    ItemTooltip tooltip;

    public event Action<Item> onRightClickEvent;

    private Item _item;
    public Item item
    {
        get { return _item; }
        set { _item = value;
            if(_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

    private void OnValidate()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
        if(tooltip == null)
        {
            tooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null && onRightClickEvent != null)
            {
                onRightClickEvent(item);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }
}
