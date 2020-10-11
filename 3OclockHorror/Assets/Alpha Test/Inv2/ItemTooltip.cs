using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Canvas parentCanvas;
    [SerializeField]
    Text ItemName;
    [SerializeField]
    Text Desc;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Vector2 movePos = new Vector2(Input.mousePosition.x + 200f, Input.mousePosition.y - 100f);
            transform.position = movePos;
        }
        
    }

    public void ShowTooltip(Item item)
    {
        ItemName.text = item.ItemName;
        if (item.Note && item.isRead)
        {
            Desc.text = item.text;
        }
        else
        {
            Desc.text = item.desc;
        }
        gameObject.SetActive(true);
    }
    public void HideTooltip()
    {
        this.gameObject.SetActive(false);
    }
}
