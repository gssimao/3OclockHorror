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
    [SerializeField]
    float interactDist;
    bool active; //Am I the active workbench inventory?
    [SerializeField]
    List<Item> Items;
    [SerializeField]
    GameObject tooltip;
    public invInput Listener;
    public GameObject invCanv;

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

    // Start is called before the first frame update
    void Start()
    {
        if (myInv == null)
        {
            myInv = gameObject.GetComponent<Inventory>();
        }
        if(interactDist == 0f)
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
        if (dist <= interactDist) //If the player is in range
        {
            //Listener.isFocus = false;
            if (uControls.Player.Interact.triggered && !active)
            {
                openInventory();
            }
            else if (uControls.Player.Interact.triggered && active)
            {
                if (invCanv.activeSelf) 
                {
                    closeInventory();
                }
            }
        }
    }

    public void openInventory()
    {
        IM.ActivateInventory(myInv);
        myInv.OpenInv();
        active = true;
        cntnrDisp.SetActive(true);
        invCanv.SetActive(true);
        tooltip.SetActive(false);
    }
    public void closeInventory()
    {
        IM.DeactivateInventory(myInv);
        active = false;
        invCanv.SetActive(false);
        cntnrDisp.SetActive(false);
    }

    //Used for Scene manager
    public void setPlayerObject(GameObject input)// used for sceneManager script
    {
        player = input;
    }
    public GameObject getPlayerObject()
    {
        return player;
    }
    public void setcntnrDisp(GameObject input)
    {
        cntnrDisp = input;
    }
    public void setIM(InventoryManager input)
    {
        IM = input;
    }
    public void settooltip(GameObject input)
    {
        tooltip = input;
    }

    public int getItemCount()
    {
        return Items.Count;
    }

    public bool containsItem( Item obj)
    {
        bool rtrn = false;

        foreach(Item item in Items)
        {
            if(item == obj)
            {
                rtrn = true;
            }
        }

        return rtrn;
    }

    public bool getActive()
    {
        return active;
    }
}
