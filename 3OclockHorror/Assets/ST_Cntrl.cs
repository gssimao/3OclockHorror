    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_Cntrl : MonoBehaviour
{
    AudioManager manager;
    PlayerMovement player;
    FloorChanger floor;
    public room myRoom;

    public bool is1stPlaying = false;
    public bool is2ndPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //manager.Play("Heavy Wind");
        if (myRoom != null && manager != null)
        {
            manager.Play("Heavy Wind");
        }

        if (myRoom != null && player.myRoom.getName() != "Outside" && is1stPlaying == false && manager != null)
        {
            if (manager != null)
            {
                manager.Play("Drone");
                manager.Play("Game ST");
                manager.Stop("Heavy Wind");
                is1stPlaying = true;
            }

            // I'll be moving all of the SoundTrack code here once the Floor Manager is complete.
        }
        else 
            is1stPlaying = false;

        if (player.myRoom.getName() == "F1HubRoom" && manager != null)
        {
            manager.Play("Clock Tick");
        }
        else
            manager.Stop("Clock Tick");
    }
}
