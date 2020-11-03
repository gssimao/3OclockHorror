using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomCntrl : MonoBehaviour
{
    public room room1;
    public room room2;

    public GameObject entrancePointRoom;
    public PlayerMovement player;
    public invInput Listener;

    public Animator transition;
    public bool transitionOnOff = true; //Use this toggle the transition on and off
    float transitionTime = 0.5f;
    float dist;
    public Animator blackWallanim;

    public GameObject crossFade;
    public GameObject blackWall;

    // Start is called before the first frame update
    void Start()
    {
        blackWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.gameObject.transform.position, this.gameObject.transform.position);
        if (dist <= 0.5)
        {
            Listener.enabled = false;
            if (Input.GetKeyDown("e") && transitionOnOff)
            {
                if (player != null) //Make sure it's not null
                {
                    if (player.myRoom == room1) //Check the room states then update as necessary
                    {
                        CameraCrossfade(player.gameObject, entrancePointRoom, player, room2);
                    }
                    else// player.myRoom == room2
                    {
                        CameraCrossfade(player.gameObject, entrancePointRoom, player, room1);
                    }
                }
            }
        }
        if (Listener != null)
        {
            Listener.enabled = true;
        }

        if(blackWallanim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.20)
        {
            crossFade.SetActive(false);
        }

        if(blackWallanim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            blackWall.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && transitionOnOff == false) //If its a player, this is necessary to determine what class to attempt to grab
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>(); //Grab the player movement script

            if (player != null) //Make sure it's not null
            {
                if(player.myRoom == room1) //Check the room states then update as necessary
                {
                    CameraCrossfade(collision.gameObject, entrancePointRoom, player, room2);
                }
                else// player.myRoom == room2
                {
                    CameraCrossfade(collision.gameObject, entrancePointRoom, player, room1);
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

    public void CameraCrossfade(GameObject player, GameObject entranceP, PlayerMovement play, room RoomNum)
    {
        StartCoroutine(ChangeCamera(player, entranceP, play, RoomNum));
    }

    IEnumerator ChangeCamera(GameObject player, GameObject entranceP, PlayerMovement play, room RoomNum)
    {
        if (transitionOnOff)
        {
            crossFade.SetActive(true);
            transition.SetTrigger("Start");
            play.enabled = false;
        }

        player.transform.position = entranceP.transform.position;

        if (transitionOnOff)
        {
            yield return new WaitForSeconds(transitionTime);
        }

        if (transitionOnOff)
        {
            blackWall.SetActive(true);
            transition.SetTrigger("End");
        }

        play.myRoom = RoomNum;

        if (transitionOnOff)
        {
            play.enabled = true;
        }
    }
}
