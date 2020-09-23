using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    public room firstRoom;
    public room secondRoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>().myRoom == firstRoom)
        {
            other.GetComponent<PlayerMovement>().myRoom = secondRoom;
        }
        else if (other.GetComponent<PlayerMovement>().myRoom == secondRoom)
        {
            other.GetComponent<PlayerMovement>().myRoom = firstRoom;
        }
    }
}
