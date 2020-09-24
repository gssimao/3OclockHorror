using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class clockCntrl : MonoBehaviour
{
    float endTime; //Stores the current end time, allows easier modification than tracking and moding systime directly
    float timePercent; //Hud controller variable, not necessary beyond using slider to display time - will be oudated once clock is added
    public Slider timeHud; //Slider itself, used to display time

    [SerializeField]
    GameObject watcher;

    [SerializeField]
    GameObject creep;

    // Start is called before the first frame update 
    void Start()
    {
        endTime = 1200.0f; //set endtime, to however long we want it to run - Adjust to full time
        watcher.SetActive(false);
        creep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= endTime) //Check if sys time is beyond end time, if so quit
        {
            SceneManager.LoadScene(2); //Load the Game Over scene
            Destroy(gameObject);
        }
        else
        {
            timePercent = Time.time / endTime;
            timeHud.value = timePercent;    //Both lines also are soley for purpose of clock ui - will be changed / removed when proper ui is devised
        }

        //Check for events
        if(Time.time >= 120)
        {
            watcher.SetActive(true);
        }
        /* - Enable once we at least have a sprite
        if(Time.time >= 240)
        {
            creep.SetActive(true);
        }
        */
    }

    public void adjustEndTime(float tta) //Takes time to adjust by, adjusts time by that amount - likely only neg values but takes either or
    {
        endTime += tta;
    }

}
