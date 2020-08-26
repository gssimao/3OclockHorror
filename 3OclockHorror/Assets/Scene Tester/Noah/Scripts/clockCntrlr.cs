using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockCntrlr : MonoBehaviour
{
    float sysTime; //Stores current system time
    float endTime; //Stores the current end time, allows easier modification than tracking and moding systime directly
    // Start is called before the first frame update
    void Start()
    {
        endTime = 60.0f; //set endtime, to however long we want it to run - Adjust to full time
    }

    // Update is called once per frame
    void Update()
    {
        sysTime = Time.time; //update systime to engine's time at beginning of frame

        if(sysTime >= endTime) //Check if logged time is beyond end time, if so quit
        {
            Application.Quit();
            Debug.Log("Would have stopped there"); //Logs to console that application would have ended
        }
    }

    public void adjustEndTime(float tta) //Takes time to adjust by, adjusts time by that amount
    {
        endTime += tta;
    }
}
