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

    int xmod;
    int ymod;

    private void Start()
    {
        xmod = (int)(gameObject.GetComponent<RectTransform>().rect.width / 2) + 100;
        ymod = (int)(gameObject.GetComponent<RectTransform>().rect.height / 2) + 50;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            updateRect();
            Vector2 movePos = new Vector2(Input.mousePosition.x + xmod, Input.mousePosition.y - ymod);
            transform.position = movePos;
        }
        
    }

    public void updateRect()
    {
        xmod = (int)(gameObject.GetComponent<RectTransform>().rect.width / 2) + 100;
        ymod = (int)(gameObject.GetComponent<RectTransform>().rect.height / 2) + 50;
    }

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
