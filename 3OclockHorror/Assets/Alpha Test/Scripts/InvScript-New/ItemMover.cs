using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    bool grabbed; //Am I being held by the mouse currently
    bool stored; //Am I being stored
    Inventory inventory; //The inventory I belong to
    int grabDelay; //Delay to allow unity to register changes in grab state
    int slotImIn; //The item slot I'm in.
    string listImIn;

    //Controllers for item variables
    public string description; //Description tag, primarily for journal entry.
    public int lvl; //Tag associated with level for placement reasons.
    public bool rand; //Can this item be randomized?

    // Start is called before the first frame update
    void Start() //Init the item state - set the various state conditions as well as the inventoy I belong to
    { 
        grabbed = false;
        stored = false;
        slotImIn = 10000; //Set this to huge number as it cannot be nulled so anything this large will act as a null state
        grabDelay = 0;

        inventory = Inventory.instance;
    }

    private void Update()
    {
        //Move depending on state, update grabbed state
        move();
        grab();
        place();

        if (grabDelay > 0) //Decrement the geab timer if active
        {
            grabDelay--;
        }
    }

    public void grab()
    {
        if (Input.GetMouseButtonDown(0) && grabDelay == 0 && !grabbed) //If the mouse is down, grab delay is gone, and I'm not grabbed - grab me
        {

            RaycastHit hit;   //Use a raycast to hit the item and allow it to update state
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject) //Grabs the tag of the gameobject we hit, and will move it if it's an ItemObject
                {
                    grabbed = true; //Update states
                    grabDelay = 5;

                    if (stored) //If stored, apply changes to the inventory as well
                    {
                        if (listImIn == "w")
                        {
                            inventory.RemoveItem(this, inventory.workbenchItems, inventory.workbenchSlots, slotImIn);
                            stored = false;
                            listImIn = "";
                            slotImIn = 10000;
                        }
                        else
                        {
                            inventory.RemoveItem(this, inventory.items, inventory.slots, slotImIn);
                            stored = false;
                            listImIn = "";
                            slotImIn = 10000;
                        }
                    }
                }
            }
        }
    }

    public void place() //Attempts to place the item if conditions are called
    {
        if (Input.GetMouseButtonDown(0) && grabDelay == 0 && grabbed) //Checks for mouse input, inactive grab delay, and if object is grabbed
        {
            if(placeInSlot(inventory.slots, inventory.items))
            {
                listImIn = "i";
            }
            if(placeInSlot(inventory.workbenchSlots, inventory.workbenchItems))
            {
                listImIn = "w";
            }
        }
    }

    public void move() //Determines if and how the item should move
    {
        if (grabbed) //If it's grabbed, it should move with the mouse - this makes it do that
        {
            Vector3 temp = Input.mousePosition; //Grab mouse pos
            temp.z = gameObject.transform.position.z + (Camera.main.transform.position.z * -1f); //Adjust zPos to represent the current item z pos with respect to the camera
            this.transform.position = Camera.main.ScreenToWorldPoint(temp); //Transform position to move with mouse
        }
    }

    public void grabSet(bool set) //Adjusts grab state publicly
    {
        grabbed = set;
        stored = false;
        grabDelay = 5;
    }

    public bool placeInSlot(inventorySlot[] slots, List<ItemMover> items) //Places the item in a valid slot. Takes the list of slots and items to put it in
    {
        int slotCount = 0; //Starts an incremental counter for which slot the item goes in
        foreach (inventorySlot slot in slots) //Runs through each slot in the inventory's slot list
        {
            Vector2 obj = gameObject.transform.position; //Grabs the position of the item and the slot that we are on
            Vector2 ui = slot.transform.position;

            float dist = Vector2.Distance(obj, ui); //Calculates the distance between them to see if the item is in range of the slot *Note - Is a little buggy. Range can be adjusted down, but that causes item to not always register slot. For now, best left as is*

            if (dist < 10f) //Checks the distance
            {
                inventory.AddItem(this, items, slots, slotCount); //Adds the item into the items list
                Vector3 slotSpace = new Vector3(ui.x, ui.y, gameObject.transform.position.z); //Adjusts the item's position to be in line with the position of the slot
                gameObject.transform.position = slotSpace; //Places the item at that location

                
                grabbed = false; //Update states
                stored = true;
                slotImIn = slotCount;
                grabDelay = 5;

                return(true);
            }
            slotCount++; //If we didn't match with a slot, increment the slot counter
        }
        return(false);
    }
}
