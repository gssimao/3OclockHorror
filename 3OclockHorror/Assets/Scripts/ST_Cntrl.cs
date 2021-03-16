using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_Cntrl : MonoBehaviour
{
    AudioManager manager;
    public PlayerMovement player;
    public HuntCheckSolved huntTrap;
    public FloorAudioController myFloor;
    //public room sRoom;
    public bool StopALL = false;
    bool is1stPlaying = false;
    bool is2ndPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.myRoom != null && player.myRoom.getName() == "Outside")
        {
            playSound("Heavy Wind");
        }

        if (player.myRoom != null && player.myRoom.getName() != "Outside" && is1stPlaying == false && player.myRoom.floorNum == 1 && StopALL == false)
        {
            playSound("Drone");
            playSound("Game ST");
            manager.Stop("Heavy Wind");
            is1stPlaying = true;
            if (is2ndPlaying == true)
            {
                manager.StartFade("2nd Floor ST", 3);
                //manager.Stop("2nd Floor ST");
                is2ndPlaying = false;
            }
        }
        else if (player.myRoom != null && player.myRoom.getName() != "Outside" && is2ndPlaying == false && player.myRoom.floorNum != 1 && StopALL == false)
        {
            manager.StartFade("Drone", 3);
            manager.StartFade("Game ST", 3);
            playSound("2nd Floor ST");
            is2ndPlaying = true;
            if (is1stPlaying == true)
            {
                manager.StartFade("Game ST", 3);
                manager.StartFade("Drone", 3);
                //manager.Stop("Game ST");
                //manager.Stop("Drone");
                is1stPlaying = false;
            }
        }

        if (player.myRoom.getName() == "F1HubRoom")
        {
            playSound("Clock Tick");
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

        if (huntTrap.HunterTrapActive == true)
        {
            StopSoundTrack();
            manager.Play("Hunter Build up", false);
        }
        else if (huntTrap.HunterTrapActive == false)
        {
            StopALL = false;
            manager.StartFade("Hunter Build up", 2);
            manager.Stop("Hunter Build up");
        }
    }

    public void playSound(string sound)
    {
        if (manager != null)
        {
            manager.Play(sound, false);
        }
        else
        {
            Debug.LogError("AudioManager not found. Likely not an error.");
        }
    }

    public void StopSoundTrack()
    {
        StopALL = true;
        if (is1stPlaying == true)
        {
            //manager.StartFade("Drone", 2);
            //manager.StartFade("Game ST", 2);
            manager.Stop("Drone");
            manager.Stop("Game ST");
        }
        else if (is2ndPlaying == true)
        {
            //manager.StartFade("2nd Floor ST", 2);
            manager.Stop("2nd Floor ST");
        }
    }
}
