using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exItem : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return Name;
        }
    }
    public Sprite _image = null;
    public Sprite image
    {
        get
        {
            return image;
        }
    }

    public string desc
    {
        get
        {
            return desc;
        }
    }

    public bool rand
    {
        get
        {
            return rand;
        }
    }

    public void OnPickup()
    {
        //Any Logic to be run on pickup
    }
    public void OnDrop()
    {
        /*
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
        */
    }
    public virtual void OnUse()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
