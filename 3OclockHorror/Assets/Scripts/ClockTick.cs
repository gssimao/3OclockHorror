using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTick : MonoBehaviour
{
    public GameObject player;
    public GameObject GrandfatherClock;

    public float soundRange;
    bool isPlaying;
    float dist;

    public room currentRoom;
    room playerRoom;
    public bool playerInRoom;

    AudioManager manager; 

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        playerRoom = player.GetComponent<PlayerMovement>().myRoom;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRoom();
        /*dist = Vector3.Distance(player.transform.position, this.transform.position);
         if (dist <= soundRange)
         {
            // playSound();
         }
         else if (dist > soundRange)
         {
            // manager.Stop("Clock Tick");
         }*/

    }

    void playSound()
    {
        if (!isPlaying && manager != null)
        {
            manager.Play("Clock Tick");
            isPlaying = true;
        }
    }

    void CheckRoom() //Checks to see if the room the watcher is in has the player
    {
        if (currentRoom == playerRoom)
        {
            playerInRoom = true;
            playSound();
        }
        else
        {
            playerInRoom = false;
            //manager.Stop("Clock Tick");
         }
    }
}
