using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField]
    Text ItemName;
    [SerializeField]
    Text Desc;

    public void ShowTooltip(Item item)
    {
        ItemName.text = item.ItemName;
        Desc.text = item.desc;
        gameObject.SetActive(true);
    }
    public void HideTooltip()
    {
        this.gameObject.SetActive(false);
    }
}
