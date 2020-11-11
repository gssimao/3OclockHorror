using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class workbench_cntrl : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Inventory myInv;
    [SerializeField]
    GameObject myInvDisplay;
    [SerializeField]
    InventoryManager IM;
    [SerializeField]
    float interactDist;
    bool active; //Am I the active workbench?
    [SerializeField]
    List<Item> Items;
    [SerializeField]
    GameObject tooltip;
    public invInput Listener;
    public GameObject invCanv;

    private void Start()
    {
        if(myInv == null)
        {
            myInv = gameObject.GetComponent<Inventory>();
        }
        if (interactDist == 0f)
        {
            interactDist = 0.25f;
        }
        if (invCanv == null)
        {
            invCanv = GameObject.FindGameObjectWithTag("invUI");
        }
        
        active = false;
        myInv.CloseInv();

        myInv.InitStartingItems(Items);
    }


    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position); //Get the position of player
        if(dist <= 0.25f) //If the player is in range
        {
            Listener.enabled = false;
            if (Input.GetKeyDown("e") && !active)
            {
                IM.ActivateInventory(myInv);
                myInv.OpenInv(); //Update the items to be in accordance with the items array
                active = true;
                myInvDisplay.SetActive(true);
                invCanv.SetActive(true);
                IM.craftField.SetActive(true);
                tooltip.SetActive(false);
            }
            else if(Input.GetKeyDown("e") && active)
            {
                IM.DeactivateInventory(myInv);
                active = false;
                invCanv.SetActive(false);
                myInvDisplay.SetActive(false);
                IM.craftField.SetActive(false);
            }
        }
        else
        {
            if(Listener != null)
            {
                Listener.enabled = true;
            }
        }
    }

    public void setPlayerObject(GameObject input)// used for sceneManager script
    {
        player = input;
    }
}
