using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsTab : Tab
{
    Item[] invItems;

    public Text[] textBoxes;
    // Update is called once per frame
    void Update()
    {
        invItems = getItems();

        for (int i = 0; i < textBoxes.Length; i++)
        {
            if (invItems[i].desc != "")
            {
                textBoxes[i].text = invItems[i].desc;
            }
            else
            {
                textBoxes[i].text = "";
            }
        }
    }
}
