using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvRandomizer : MonoBehaviour
{
    [SerializeField]
    Inventory[] inventories; //Holds all standard item containers.
    [SerializeField]
    Item[] items; //Holds all items that can be completely randomized.

    // Start is called before the first frame update
    void Start()
    {
        SelectRandomStartInvs();
    }

    public void SelectRandomStartInvs()
    {
        foreach (Item item in items)
        {
            int indx = Random.Range(0, inventories.Length);
            while (inventories[indx].IsFull())
            {
                indx = Random.Range(0, inventories.Length);
            }
            inventories[indx].AddItem(item);
        }
    }
}
