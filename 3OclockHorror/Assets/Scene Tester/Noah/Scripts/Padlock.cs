﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padlock : MonoBehaviour
{
    //Rotating elements of the lock
    [SerializeField]
    LockControl lock1;
    [SerializeField]
    LockControl lock2;
    [SerializeField]
    LockControl lock3;
    [SerializeField]
    LockControl lock4;

    //List of doors to be unlocked when called
    [SerializeField]
    List<roomCntrl> doors;

    //List of photos to check lock against
    [SerializeField]
    Item Photo1;
    [SerializeField]
    Item Photo2;
    [SerializeField]
    Item Photo3;
    [SerializeField]
    Item Photo4;

    bool solved;
    // Update is called once per frame
    void Update()
    {
        CheckAnswer();
    }

    public void CheckAnswer()
    {
        if (!solved) //Before checking, see if the puzzle is solved already
        {
            if (lock1.numeral == Photo1.numeral) //Check each photo and rotor combination to see if they match properly
            {
                if (lock2.numeral == Photo2.numeral)
                {
                    if (lock3.numeral == Photo3.numeral)
                    {
                        if (lock4.numeral == Photo4.numeral)
                        {
                            foreach (roomCntrl door in doors) //If they all match, unlock all respective doors assigned to this function
                            {
                                door.locked = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
