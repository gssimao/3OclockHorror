using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvRandomizer : MonoBehaviour
{
    [SerializeField]
    Inventory[] inventories; //Holds all standard item containers for randomized items.
    [SerializeField]
    Item[] items; //Holds all items that can be completely randomized.

    // Start is called before the first frame update
    void Awake()
    {
        SelectRandomStartInvs(); //Randomize the items
    }

    public void SelectRandomStartInvs()
    {
        foreach (Item item in items) //Go through each item to be randomized
        {
            if (item.rand) //If the item should be randomized (Technically redundant but make sure we're randomizing randomizables)
            {
                int indx = Random.Range(0, inventories.Length); //Get a random index for the item
                while (inventories[indx].IsFull()) //Check if its full
                {
                    indx = Random.Range(0, inventories.Length); //If so, grab a new one 
                }
                inventories[indx].AddStartingItem(item); //Place the item in the selected container
            }
        }
    }
}
