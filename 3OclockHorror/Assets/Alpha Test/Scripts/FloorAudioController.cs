using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAudioController : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;

    float t = 0;
    int floor;
    int lFloor;

    // Update Function, WIP not yet finished
    void Update()
    {
        if(t == 0)
        {
            //Catch the last floor, might be necessary 
            lFloor = floor;
            CheckFloor();

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
                    break;
                case 4:
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
        if(player.playerFloor == "FirstFloor")
        {
            floor = 1;
        }
        else if(player.playerFloor == "SecondFloor")
        {
            floor = 2;
        }
        else if(player.playerFloor == "ThirdFloor")
        {
            floor = 3;
        }
        else if(player.playerFloor == "Basement")
        {
            floor = 4;
        }
        else
        {
            FloorControlError();
            floor = 20;
        }
    }

    //Functions for floor one
    #region Floor One
    public void PlayFloorOne()
    {
        //This is where the music will go.
    }
    #endregion
    //Functions for floor two
    #region Floor Two
    public void CheckFloorTwo()
    {

    }
    public void PlayFloorTwoA()
    {
        //Music for the left side goes here
    }
    public void PlayFloorTwoB()
    {
        //Music for the right side goes here
    }
    #endregion
    //Functions for floor three
    #region Floor Three

    #endregion
    //Functions for basement
    #region Basement
    #endregion
    //In case of error
    #region Error Catch
    public void FloorControlError()
    {
        Debug.LogError("The Audio Floor Controller script has broken, due to a bug.");
        if(floor == 20)
        {
            Debug.Log("The error was in the Player's floor. The floor could not be reconciled with possible floors.");
        }
    }
    #endregion
}
