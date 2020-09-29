using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerControl : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Inventory myInv;
    [SerializeField]
    GameObject cntnrDisp;
    [SerializeField]
    InventoryManager IM;
    bool active; //Am I the active workbench inventory?

    Item[] myItems;

    // Start is called before the first frame update
    void Start()
    {
        if (myInv == null)
        {
            myInv = gameObject.GetComponent<Inventory>();
        }
        if (myItems != null)
        {
            foreach (Item item in myItems)
            {
                myInv.AddStartingItem(item);
            }
        }
        active = false;
        myInv.CloseInv();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position); //Get the position of player
        if (dist <= 0.25f) //If the player is in range
        {
            if (Input.GetKeyDown("e") && !active)
            {
                IM.ActivateInventory(myInv);
                myInv.OpenInv(); //Update the items to be in accordance with the items array
                active = true;
                cntnrDisp.SetActive(true);
                IM.craftField.SetActive(true);
            }
            else if (Input.GetKeyDown("e") && active)
            {
                IM.DeactivateInventory(myInv);
                active = false;
                cntnrDisp.SetActive(false);
                IM.craftField.SetActive(false);
            }
        }
    }
}
