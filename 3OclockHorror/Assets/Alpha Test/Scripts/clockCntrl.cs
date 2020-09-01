using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clockCntrl : MonoBehaviour
{
    float endTime; //Stores the current end time, allows easier modification than tracking and moding systime directly
    float timePercent; //Hud controller variable, not necessary beyond using slider to display time - will be oudated once clock is added
    public Slider timeHud; //Slider itself, used to display time

    // Start is called before the first frame update 
    void Start()
    {
        endTime = 10.0f; //set endtime, to however long we want it to run - Adjust to full time
    }

    // Update is called once per frame
    void Update()
    {
        timePercent = Time.time / endTime;
        timeHud.value = timePercent;    //Both lines also are soley for purpose of clock ui - will be changed / removed when proper ui is devised

        if (Time.time >= endTime) //Check if sys time is beyond end time, if so quit
        {
            Application.Quit();
            Debug.Log("Would have stopped there"); //Logs to console that application would have ended, not necessary in final version just for tracking in editor
        }
    }

    public void adjustEndTime(float tta) //Takes time to adjust by, adjusts time by that amount - likely only neg values but takes either or
    {
        endTime += tta;
    }

}
