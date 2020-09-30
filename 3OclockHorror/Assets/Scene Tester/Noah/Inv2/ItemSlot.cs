using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField]
    Image image;

    public event Action<ItemSlot> onPointerEnterEvent;
    public event Action<ItemSlot> onPointerExitEvent;
    public event Action<ItemSlot> onRightClickEvent;
    public event Action<ItemSlot> onBeginDragEvent;
    public event Action<ItemSlot> onEndDragEvent;
    public event Action<ItemSlot> onDragEvent;
    public event Action<ItemSlot> onDropEvent;


    private Color normColor = Color.white;
    private Color disabledColor = new Color(255, 255, 255, 0.1f);

    private Item _item;
    public Item Item
    {
        get { return _item; }
        set { _item = value;}
    }

    public void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }
    public void Update()
    {
        if(Item == null)
        {
            image.sprite = null;
            image.color = disabledColor;
        }
        else
        {
            image.sprite = _item.Icon;
            image.color = normColor;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            onRightClickEvent?.Invoke(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onPointerEnterEvent?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerExitEvent?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onEndDragEvent?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        onBeginDragEvent?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDragEvent?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        onDropEvent?.Invoke(this);
    }

    public virtual bool CanRecieveItem(Item item)
    {
        return true;
    }
}
