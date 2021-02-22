using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_Cntrl : MonoBehaviour
{
    AudioManager manager;
    public PlayerMovement player;
    FloorChanger floor;
    //public room sRoom;

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
        if (player.myRoom != null && manager != null && player.myRoom.getName() == "Outside")
        {
            manager.Play("Heavy Wind");
        }

        if (player.myRoom != null && player.myRoom.getName() != "Outside" && is1stPlaying == false && manager != null && player.myRoom.floorNum == 1)
        {
            manager.Play("Drone");
            manager.Play("Game ST");
            manager.Stop("Heavy Wind");
            manager.StartFade("2nd Floor ST", 10);
            is1stPlaying = true;
            // I'll be moving all of the SoundTrack code here once the Floor Manager is complete.
        }
        else if (player.myRoom != null && player.myRoom.getName() != "Outside" && is2ndPlaying == false && manager != null && player.myRoom.floorNum == 2)
        {
            manager.StartFade("Drone", 10);
            manager.StartFade("Game ST", 10);
            //manager.Play("2nd Floor ST");
            is1stPlaying = false;

        }
        if (player.myRoom.getName() == "F1HubRoom" && manager != null)
        {
            manager.Play("Clock Tick");
        }
        else
        {
            if (manager != null)
            {
                manager.Stop("Clock Tick");
            }
            else
            {
                Debug.LogError("AudioManager not found. Likely not an error.");
            }
        }
    }
}
