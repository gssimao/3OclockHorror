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
    bool windplaying = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager != null)
        {
            if (player.myRoom != null && player.myRoom.getName() == "Outside")
            {
                playSound("Heavy Wind");
                windplaying = true;
            }
            else if (player.myRoom.getName() == "F1HubRoom" && clock.hourIsPlaying == false)
            {
                playSound("Clock Tick");
                //clock.hourIsPlaying = true; - These broke the variable's function and caused hours after 5 to trigger no sound. - Noah
            }
            else
            {
                if (windplaying)
                {
                    manager.Stop("Heavy Wind");
                    windplaying = false;
                }
                if (clock.hourIsPlaying == true)
                {
                    manager.Stop("Clock Tick");
                    //clock.hourIsPlaying = false;
                }
                else if (player.myRoom.getName() != "F1HubRoom")
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
