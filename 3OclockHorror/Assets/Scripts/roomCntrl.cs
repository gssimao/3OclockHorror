using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomCntrl : MonoBehaviour
{
    public room room1;
    public room room2; //DestRoom

    public GameObject entrancePointRoom;
    public PlayerMovement player;
    public invInput Listener;
    public Tooltip toolTipScript;

    public bool transitionOnOff = true; //Use this toggle the transition on and off
    public float range = 0.5f;
    float transitionTime = 0.5f;
    float dist;

    public bool locked;
    public Inventory pInv;
    public Item MyKey;

    [SerializeField]
    GameObject lockCanv;
    [SerializeField]
    TaskListTracker taskManager;

    AudioManager manager;

    public Animator Fade;

    bool opened = false;
    
    public bool WatchHallwayTrigger = false;
    WatcherAI watcher;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();

        if(WatchHallwayTrigger)
        {
            watcher = FindObjectOfType<WatcherAI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.gameObject.transform.position, this.gameObject.transform.position);
        if (dist <= range)
        {
            Listener.enabled = false;
            if (Input.GetKeyDown("e") && transitionOnOff)
            {
                if (locked)
                {
                    CheckKey();
                }

                if (player != null && !locked) //Make sure it's not null, check if door is locked
                {
                    if (player.myRoom == room1) //Check the room states then update as necessary
                    {
                        CameraCrossfade(player.gameObject, entrancePointRoom, player, room2);
                        if(manager != null)
                        {
                            manager.Play("Door Open", true);
                        }
                    }
                    else// player.myRoom == room2
                    {
                        CameraCrossfade(player.gameObject, entrancePointRoom, player, room1);
                        if (manager != null)
                        {
                            manager.Play("Door Open", true);
                        }
                    }
                }
            }
        }
        if (Listener != null)
        {
            Listener.enabled = true;
        }

        if (Fade != null)
        {
            if(Fade.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Fade.gameObject.SetActive(false);
            }
        }

        if(WatchHallwayTrigger)
        {
            if(player.myRoom != room2)
            {
                watcher.WatcherHallway = false;
            }
        }
    }
    void OnDrawGizmos()//Shows how far the play needs to be in order to use the door
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(gameObject.transform.position, range);
        Vector3 plyPos = entrancePointRoom.transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(plyPos.x, plyPos.y - 0.3108585f, plyPos.z), new Vector3(0.1573486f, 0.1247783f, 1f));
    }
    private void OnDrawGizmosSelected()//Draws a line between the door and it's destination, which is markered by a red circle
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(gameObject.transform.position, entrancePointRoom.transform.position);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(entrancePointRoom.transform.position, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && transitionOnOff == false && !locked) //If its a player, this is necessary to determine what class to attempt to grab
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
        if (WatchHallwayTrigger)
        {
            watcher.WatcherHallway = true;
            player.GetComponent<LightMatch>().enabled = false;
        }

        StartCoroutine(ChangeCamera(player, entranceP, play, RoomNum));
    }

    IEnumerator ChangeCamera(GameObject player, GameObject entranceP, PlayerMovement play, room RoomNum)
    {
        if (transitionOnOff)
        {
            Fade.gameObject.SetActive(true);
            Fade.SetTrigger("fadeOut");
        }

        player.transform.position = entranceP.transform.position;

        if (transitionOnOff)
        {
            yield return new WaitForSeconds(transitionTime);
            Fade.SetTrigger("fadeIn");
        }

        play.myRoom = RoomNum;
    }

    public void CheckKey()
    {
        if (pInv != null && MyKey != null)
        {
            if (pInv.ContainsItem(MyKey))
            {
                locked = false;
            }
            else
            {
                toolTipScript.TimedMessage = "The door is locked";
                if(manager != null)
                {
                    manager.Play("Locked Door", false);
                }
            }
        }
        else if(lockCanv != null && !lockCanv.activeSelf)
        {
            lockCanv.SetActive(true);
            if (!opened)
            {
                taskManager.updateList("\n - A lock with roman numerals? Where would I get the code?");
                opened = true;
            }
        }
        else
        {
            toolTipScript.TimedMessage = "The door is locked";
            Debug.LogError("Door is locked but there is no key or inv set");
        }
    }
}
