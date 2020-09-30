using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomCntrl : MonoBehaviour
{
    public room room1;
    public room room2;

    public GameObject entrancePointRoom1;
    public GameObject entrancePointRoom2;

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
        Vector3 tmp;
        if (collision.gameObject.tag == "Player") //If its a player, this is necessary to determine what class to attempt to grab
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>(); //Grab the player movement script

            tmp = new Vector3(player.movement.x * 0.5f, player.movement.y * 0.5f, 0.0f);

            if (player != null) //Make sure it's not null
            {
                if(player.myRoom == room1) //Check the room states then update as necessary
                {
                    player.myRoom = room2;
                    collision.transform.position = entrancePointRoom2.transform.position + tmp;
                }
                else
                {
                    player.myRoom = room1;
                    collision.transform.position = entrancePointRoom1.transform.position + tmp;
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
