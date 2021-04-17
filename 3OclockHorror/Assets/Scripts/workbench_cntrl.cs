using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    //private GameObject[] ItemPopups;

    UniversalControls uControls;
    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();
    }
    private void OnDisable()
    {
        uControls.Disable();
    }
    private void Start()
    {
        //ItemPopups = GameObject.FindGameObjectsWithTag("ItemPopup");
        if (myInv == null)
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
        if (dist <= 0.25f) //If the player is in range
        {
            Debug.Log("Within Range");
            //Listener.isFocus = false;
            if (uControls.Player.Interact.triggered && !active)
            {
                Debug.Log("Inside Trigger/off");
                IM.ActivateInventory(myInv);
                myInv.OpenInv(); //Update the items to be in accordance with the items array
                active = true;
                myInvDisplay.SetActive(true);
                invCanv.SetActive(true);
                IM.craftField.SetActive(true);
                tooltip.SetActive(false);
            }
            else if (uControls.Player.Interact.triggered && active)
            {
                Debug.Log("Inside Trigger/on");
                //if (invCanv.activeSelf)
                //{
                    IM.DeactivateInventory(myInv);
                    active = false;
                    invCanv.SetActive(false);
                    myInvDisplay.SetActive(false);
                    IM.craftField.SetActive(false);
                //}
            }
        }
    }

    //For checking Item Popup collision
    /*private bool CheckItemCollision()
    {
        foreach (GameObject ItemPopup in ItemPopups)
        {
            if (ItemPopup.GetComponent<ObjectRender>().colliding == true)
            {
                return true;
            }
        }
        return false;
    }*/
    public void open()
    {
        IM.ActivateInventory(myInv);
        myInv.OpenInv(); //Update the items to be in accordance with the items array
        active = true;
        myInvDisplay.SetActive(true);
        invCanv.SetActive(true);
        IM.craftField.SetActive(true);
        tooltip.SetActive(false);
    }
    public void close()
    {
        IM.DeactivateInventory(myInv);
        active = false;
        invCanv.SetActive(false);
        myInvDisplay.SetActive(false);
        IM.craftField.SetActive(false);
    }

    /*private void Inventory(InputAction.CallbackContext c)
    {
        if(!active)
        {
            IM.ActivateInventory(myInv);
            myInv.OpenInv(); //Update the items to be in accordance with the items array
            active = true;
            myInvDisplay.SetActive(true);
            invCanv.SetActive(true);
            IM.craftField.SetActive(true);
            tooltip.SetActive(false);
        }
        else
        {
            IM.DeactivateInventory(myInv);
            active = false;
            invCanv.SetActive(false);
            myInvDisplay.SetActive(false);
            IM.craftField.SetActive(false);
        }
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        uControls.Player.Interact.performed += Inventory;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uControls.Player.Interact.performed -= Inventory;
    }*/
}
