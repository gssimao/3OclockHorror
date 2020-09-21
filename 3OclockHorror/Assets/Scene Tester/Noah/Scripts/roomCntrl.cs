using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomCntrl : MonoBehaviour
{
    public room room1;
    public room room2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //If its a player, this is necessary to determine what class to attempt to grab
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>(); //Grab the player movement script
            if(player != null) //Make sure it's not null
            {
                if(player.myRoom == room1) //Check the room states then update as necessary
                {
                    player.myRoom = room2;
                }
                else
                {
                    player.myRoom = room1;
                }
            }
        }
        else
        {
            //Same logic flow, just uses an NPC class instead of a playermovement class
            NPC exe = collision.gameObject.GetComponent<NPC>();
            if(exe != null)
            {
                if(exe.myRoom == room1)
                {
                    exe.myRoom = room2;
                }
                else
                {
                    exe.myRoom = room1;
                }
            }
        }
    }
}
