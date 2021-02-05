using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemsTab : Tab
{
    public GameObject itemTab;
    Item[] inventoryItems;
    public TextMeshProUGUI[] textBoxes;

    private void Start()
    {
        textBoxes = itemTab.GetComponentsInChildren<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        inventoryItems = getItems();

        for (int i = 0; i < textBoxes.Length; i++)
        {
            if (inventoryItems[i].desc != "")
            {
                textBoxes[i].text = inventoryItems[i].desc;
            }
            else
            {
                textBoxes[i].text = "";
            }
        }
    }
}
