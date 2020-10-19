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

    float xmod;
    float ymod;

    private void Start()
    {
        xmod = (gameObject.GetComponent<RectTransform>().rect.width / 2) + 10;
        ymod = (gameObject.GetComponent<RectTransform>().rect.height / 2) + 10;

    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Vector2 movePos = new Vector2(Input.mousePosition.x + xmod, Input.mousePosition.y - ymod);
            transform.position = movePos;
        }
        
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
