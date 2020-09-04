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
            foreach(inventorySlot slot in inventory.slots)
            {
                /*
                float dist = Vector3.Distance(slot.transform.position, gameObject.transform.position);
                Debug.Log("Dist: " + dist);
                */

                Vector3 obj1 = slot.transform.localPosition;
                Vector3 obj2 = gameObject.transform.position;
                Vector3 obj1Cast = Camera.main.ScreenToWorldPoint(obj1);
                Debug.Log("Canv X: " + obj1.x + " Y: " + obj1.y);;
                Vector3 obj2Cast = Camera.main.ScreenToWorldPoint(obj2);
                Debug.Log("Obj X:" + obj2.x + " Y: " + obj2.y);
                float dist = Vector3.Distance(obj1, obj2);

                if(dist < 1)
                {
                    inventory.AddItem(myItem);
                    gameObject.transform.position = new Vector3(obj1Cast.x, obj1Cast.y, gameObject.transform.position.z);

                    grabbed = false;
                    stored = true;
                    grabDelay = 5;

                    return;
                }
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
