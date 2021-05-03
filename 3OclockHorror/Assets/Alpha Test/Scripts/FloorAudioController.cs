using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAudioController : MonoBehaviour
{
    [SerializeField]
    public PlayerMovement player;
    public AudioManager manager;

    [Space]
    [SerializeField]
    List<room> Floor2A;
    /*
    [SerializeField]
    ArrayLayout Floor2B;
    */

    float t = 0;
    public int floor;
    //public room Rfloor;
    //public int prevFloorAudio = 0;
    public int lFloor;
    public bool StopALL = false;
    public bool is2ATrue = false;
    public bool is2BTrue = false;

    private void Awake()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update Function, WIP not yet finished
    void Update()
    {
        if (t <= 0 && player.myRoom.getName() != "Outside")
        {
            lFloor = floor; //Catch the last floor
            CheckFloor();
            if(lFloor != floor)
            {
                stopSoundPerFloor();
            }

            //Rfloor = player.myRoom;
            //lFloor = floor.floorNum;

            //Determine which functions are to be called
            if (StopALL != true)
            {
                switch (floor)
                {
                    case 1:
                        PlayFloorOne();
                        break;
                    case 2:
                        CheckFloorTwo();
                        break;
                    case 3:
                        PlayFloorThree();
                        break;
                    case 4:
                        PlayBasement();
                        break;
                    case 20:
                        break;
                }
            }

            //Reset the timer
            t = 0.5f;
        }
        else
        {
            t -= Time.deltaTime;
        }
    }

    public void stopSoundPerFloor()
    {
        if (player.playerFloor == "FirstFloor")
        {
            manager.Stop("Heavy Wind");
            manager.Stop("2nd Floor ST");
            manager.Stop("3rd Floor ST");
            manager.Stop("Basement ST");
        }
        else if (player.playerFloor == "SecondFloor")
        {
            manager.Stop("Drone");
            manager.Stop("Game ST");
            manager.Stop("3rd Floor ST");
            manager.Stop("Basement ST");
        }
        else if (player.playerFloor == "ThirdFloor")
        {
            manager.Stop("Heavy Wind");
            manager.Stop("Drone");
            manager.Stop("Game ST");
            manager.Stop("2nd Floor ST");
            manager.Stop("Basement ST");
        }
        else if (player.playerFloor == "Basement")
        {
            manager.Stop("Heavy Wind");
            manager.Stop("Drone");
            manager.Stop("Game ST");
            manager.Stop("2nd Floor ST");
            manager.Stop("3rd Floor ST");
        }
    }

    //Update the floor variable
    public void CheckFloor()
    {
        if (StopALL == true)
        {
            floor = 5;
        }
        else if (player.playerFloor == "FirstFloor")
        {
            floor = 1;
        }
        else if (player.playerFloor == "SecondFloor")
        {
            floor = 2;
        }
        else if (player.playerFloor == "ThirdFloor")
        {
            floor = 3;
        }
        else if (player.playerFloor == "Basement")
        {
            floor = 4;
        }
        else
        {
            FloorControlError();
            floor = 20;
        }
    }

    public void StopSoundTrack()
    {
        StopALL = true;
        manager.StopAll(); 
        /*
       manager.Stop("Heavy Wind");
        manager.Stop("Drone");
        manager.Stop("Game ST");
        manager.Stop("2nd Floor ST");
        manager.Stop("3rd Floor ST");
        manager.Stop("Basement ST");
        */
    }

    private void playSound(string sound)
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

    //Regions for each floor. Click the little plus on the left end of the line to open the region and add in the music files

    //Functions for floor one
    #region Floor One
    public void PlayFloorOne()
    {
        playSound("Drone");
        playSound("Game ST");
    }
    #endregion
    //Functions for floor two
    #region Floor Two
    public void CheckFloorTwo()
    {
        //PlayFloorTwoA(); // Test
        foreach (room room in Floor2A)
        {
            if (player.myRoom == room)
            {
                Debug.Log("Room: " + room.name + " passed");
                PlayFloorTwoA();
                return;
            }
        }
        PlayFloorTwoB();
    }
    public void PlayFloorTwoA() //Watcher side
    {
        if (is2ATrue == false)
        {
            is2ATrue = true;
            if (is2BTrue == true)
                manager.Stop("2nd Floor ST");
            is2BTrue = false;
        }
        manager.Play("Heavy Wind", false);
    }
    public void PlayFloorTwoB() //Normal side
    {
        if (is2BTrue == false)
        {
            is2BTrue = true;
            if (is2ATrue == true)
                manager.Stop("Heavy Wind");
            is2ATrue = false;
        }
        manager.Play("2nd Floor ST", false);
    }
    #endregion
    //Functions for floor three
    #region Floor Three
    public void PlayFloorThree()
    {
        playSound("3rd Floor ST");
    }
    #endregion 
    //Functions for basement
    #region Basement
    public void PlayBasement()
    {
        playSound("Basement ST");
    }
    #endregion
    //In case of error
    #region Error Catch
    public void FloorControlError()
    {
        Debug.LogError("The Audio Floor Controller script has broken, due to a bug.");
        if(lFloor == 20)
        {
            Debug.Log("The error was in the Player's floor. The floor could not be reconciled with possible floors.");
        }
    }
    #endregion
}
