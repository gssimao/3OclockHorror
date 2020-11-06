using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class clockCntrl : MonoBehaviour
{
    float endTime; //Stores the current end time, allows easier modification than tracking and moding systime directly
    public int WatcherTime = 120;
    public int CreepTime = 240;
    public PlayerMovement player;

    [SerializeField]
    float Clock = 0;

    [SerializeField]
    GameObject minuteHand;

    [SerializeField]
    GameObject hourHand;

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
        if (player.myRoom != null && player.myRoom.getName() != "TutorialRoom")
        {
            Clock += Time.deltaTime;

            if (Clock >= endTime) //Check if sys time is beyond end time, if so quit
            {
                SceneManager.LoadScene(2); //Load the Game Over scene
            }
            else
            {
                /*timePercent = Time.time / endTime;
                timeHud.value = timePercent;    //Both lines also are soley for purpose of clock ui - will be changed / removed when proper ui is devised*/
                hourHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-0.25f * Time.deltaTime));
                minuteHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-3f * Time.deltaTime));
            }

            //Check for events
            if (Clock >= WatcherTime)
            {
                watcher.SetActive(true);
            }
            if (Clock >= CreepTime)
            {
                creep.SetActive(true);
            }
        }
    }

    public void adjustEndTime(float tta) //Takes time to adjust by, adjusts time by that amount - likely only neg values but takes either or
    {
        endTime += tta;
    }

}
