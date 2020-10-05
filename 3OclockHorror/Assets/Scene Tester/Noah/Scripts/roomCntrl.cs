using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomCntrl : MonoBehaviour
{
    public room room1;
    public room room2;

    public GameObject entrancePointRoom1;
    public GameObject entrancePointRoom2;

    public Animator transition;
    float transitionTime = 0.5f;
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
                    CameraCrossfade(collision, entrancePointRoom2, tmp, player, room2);
                }
                else
                {
                    CameraCrossfade(collision, entrancePointRoom1, tmp, player, room1);
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

    public void CameraCrossfade(Collider2D player, GameObject entranceP, Vector3 tmp, PlayerMovement play, room RoomNum)
    {
        StartCoroutine(ChangeCamera(player, entranceP, tmp, play, RoomNum));
    }

    IEnumerator ChangeCamera(Collider2D player, GameObject entranceP, Vector3 tmp, PlayerMovement play, room RoomNum)
    {
        transition.SetTrigger("Start");

        player.transform.position = entranceP.transform.position + tmp;

        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("End");

        play.myRoom = RoomNum;
    }
}
