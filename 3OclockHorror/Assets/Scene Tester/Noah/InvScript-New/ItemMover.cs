using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    bool grabbed;
    bool stored;
    public Item myItem;
    public SpriteRenderer myIcon;
    Inventory inventory;
    int grabDelay;

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
        myIcon.sprite = myItem.sprite;
        grabDelay = 0;

        inventory = Inventory.instance;
    }

    private void Update()
    {
        //Use any/all of the below items.
        move();
        grab();
        place();
        
        if(grabDelay > 0)
        {
            grabDelay--;
        }
    }

    public void grab()
    {
        if (Input.GetMouseButtonDown(0) && grabDelay == 0 && !grabbed)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "ItemObject")
                {
                    grabbed = true;
                    grabDelay = 5;

                    if(stored)
                    {
                        inventory.RemoveItem(myItem);
                        stored = false;
                    }
                }
            }
        }
    }

    public void place()
    {
        if(Input.GetMouseButtonDown(0) && grabDelay == 0 && grabbed)
        {
            int slotCount = 0;
            foreach(inventorySlot slot in inventory.slots)
            {

                Vector2 obj = Camera.main.WorldToViewportPoint(gameObject.transform.position);
                Vector2 objScaled = new Vector2(obj.x * inventory.UI.sizeDelta.x, obj.y * inventory.UI.sizeDelta.y);
                //Vector2 obj = gameObject.transform.position;
                //Vector2 ui = new Vector2(slot.transform.position.x/inventory.UI.sizeDelta.x, slot.transform.position.y / inventory.UI.sizeDelta.y);
                Vector2 ui = slot.transform.position;

                float dist = Vector2.Distance(obj, ui);

                Debug.Log("Coords: " + objScaled.x + " " + objScaled.y + " UI Coords: (Slot: "+slotCount+" ) " + ui.x + " " + ui.y + " Dist: " + dist);

                if (dist < 150f && !slot.inUse)
                {
                    inventory.AddItem(myItem);
                    //Vector3 objPos = Camera.main.WorldToViewportPoint(ui);
                    gameObject.transform.position = ui;

                    grabbed = false;
                    stored = true;
                    grabDelay = 5;

                    return;
                }
                slotCount++;
            }
        }
    }

    public void move()
    {
        if(grabbed)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
    }
}
