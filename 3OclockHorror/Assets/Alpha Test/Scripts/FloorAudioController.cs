using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAudioController : MonoBehaviour
{
    [SerializeField]
    public PlayerMovement player;
    AudioManager manager;

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
        if (t <= 0)
        {
            lFloor = floor; //Catch the last floor
            CheckFloor();

            //Rfloor = player.myRoom;
            //lFloor = floor.floorNum;

            //Determine which functions are to be called
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
                case 0:
                    PlayBasement();
                    break;
                case 20:
                    break;
            }

            //Reset the timer
            t = 1.2f;
        }
        else
        {
            t -= Time.deltaTime;
        }
    }

    //Update the floor variable
    public void CheckFloor()
    {
        if (player.playerFloor == "FirstFloor")
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
        checkPrevFloor(floor);
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

    public void checkPrevFloor(int floorN)
    {
        switch(floorN)
        { 
            case 1:
                //manager.StartFade("Drone", 2);
                //manager.StartFade("Game ST", 2);
                manager.Stop("Drone");
                manager.Stop("Game ST");
                break;
            case 2:
                //manager.StartFade("2nd Floor ST", 2);
                manager.Stop("2nd Floor ST");
                break;
            case 3:
                manager.Stop("3rd Floor ST");
                //manager.StartFade("3rd Floor ST", 2);
                break;
            case 4:
                //manager.StartFade("Basement ST", 2);
                manager.Stop("Basement ST");
                break;
            default:
                break;
        }
    }

    //Regions for each floor. Click the little plus on the left end of the line to open the region and add in the music files

    //Functions for floor one
    #region Floor One
    public void PlayFloorOne()
    {
        if (StopALL == false && floor != lFloor && player.myRoom.getName() != "Outside")
        {
            Debug.Log("Passed check");
            checkPrevFloor(lFloor);
            playSound("Drone");
            playSound("Game ST");
            manager.Stop("Heavy Wind");
        }
    }
    #endregion
    //Functions for floor two
    #region Floor Two
    public void CheckFloorTwo()
    {
        PlayFloorTwoA(); // Test
        foreach (room room in Floor2A)
        {
            if(player.myRoom == room)
            {
                //Debug.Log("Passed check2B");
                PlayFloorTwoA();
            }
            else
            {
                //Can either keep as is or write code to check rooms on left side
                PlayFloorTwoB();
                //Debug.Log("Passed check2A");
            }
        }
    }
    public void PlayFloorTwoA()
    {
        if (StopALL == false && floor != lFloor && is2ATrue == false)
        {
            checkPrevFloor(lFloor);
            manager.Play("2nd Floor ST", false);
            is2ATrue = true;
            if (is2BTrue == true)
                manager.Stop("Heavy Wind");
            is2BTrue = false;
        }
    }
    public void PlayFloorTwoB()
    {
        if (StopALL == false && floor != lFloor && is2BTrue == false)
        {
            checkPrevFloor(lFloor);
            manager.Play("Heavy Wind", false);
            is2BTrue = true;
            if (is2ATrue == true)
                manager.Stop("2nd Floor ST");
            is2ATrue = false;
        }
    }
    #endregion
    //Functions for floor three
    #region Floor Three
    public void PlayFloorThree()
    {
        if (StopALL == false && floor != lFloor)
        {
            Debug.Log("Passed 3rd floor check");
            checkPrevFloor(lFloor);
            playSound("3rd Floor ST");
        }
    }
    #endregion 
    //Functions for basement
    #region Basement
    public void PlayBasement()
    {
        if (StopALL == false && floor != lFloor)
        {
            Debug.Log("Passed Basement check");
            checkPrevFloor(lFloor);
            playSound("Basemment");
        }
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
