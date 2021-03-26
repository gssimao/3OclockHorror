using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_Cntrl : MonoBehaviour
{
    AudioManager manager;
    public PlayerMovement player;
    public HuntCheckSolved huntTrap;
    public FloorAudioController myFloor;
    public clockCntrl clock;
    public FloorAudioController floorAudio;
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


        if (player.myRoom.getName() == "F1HubRoom" && clock.hourIsPlaying == false)
        {
            playSound("Clock Tick");
            clock.hourIsPlaying = true;
        }
        else
        {
            if (clock.hourIsPlaying == true)
            {
                manager.Stop("Clock Tick");
                clock.hourIsPlaying = false;
            }
            else
            {
                Debug.LogError("AudioManager not found. Likely not an error.");
            }
        }

        if (huntTrap.HunterTrapActive == true)
        {
            floorAudio.StopSoundTrack();
            manager.Play("Hunter Build up", false);
        }
        else if (huntTrap.HunterTrapActive == false)
        {
            floorAudio.StopALL = false;
            manager.StartFade("Hunter Build up", 2);
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
}
