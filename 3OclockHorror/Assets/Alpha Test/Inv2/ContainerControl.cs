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
    GameObject tooltip;
    [SerializeField]
    float interactDist;
    bool active; //Am I the active workbench inventory?
    public invInput Listener;
    public GameObject invCanv;

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
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position); //Get the position of player
        if (dist <= interactDist) //If the player is in range
        {
            Listener.enabled = false;
            if (Input.GetKeyDown("e") && !active)
            {
                IM.ActivateInventory(myInv);
                myInv.OpenInv();
                active = true;
                cntnrDisp.SetActive(true);
                invCanv.SetActive(true);
                tooltip.SetActive(false);
            }
            else if (Input.GetKeyDown("e") && active)
            {
                IM.DeactivateInventory(myInv);
                active = false;
                invCanv.SetActive(false);
                cntnrDisp.SetActive(false);
            }
        }
        else
        {
            if (Listener != null)
            {
                Listener.enabled = true;
            }
        }
    }
}
