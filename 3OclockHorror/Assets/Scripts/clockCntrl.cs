﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class clockCntrl : MonoBehaviour
{
    float endTime; //Stores the current end time, allows easier modification than tracking and moding systime directly
    public int WatcherTime = 240;
    public int CreepTime = 480;
    public PlayerMovement player;
    AudioManager manager;

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

    public WatcherAI watcherAI;
    // Start is called before the first frame update 
    void Start()
    {
        endTime = 2400.0f; //set endtime, to however long we want it to run - Adjust to full time
        watcher.SetActive(false);
        creep.SetActive(false);
        manager = FindObjectOfType<AudioManager>();
        watcherAI = watcher.GetComponent<WatcherAI>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.myRoom != null && player.myRoom.getName() != "Outside")
        {
            Clock += Time.deltaTime;

            if (Clock >= endTime) //Check if sys time is beyond end time, if so quit
            {
                SceneManager.LoadScene(2); //Load the Game Over scene
                Cursor.visible = true;
            }
            else
            {
                hourHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-0.25f * Time.deltaTime));
                minuteHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-3f * Time.deltaTime));
            }

            //Check for events
            if (Clock >= WatcherTime)
            {
                watcher.SetActive(true);
            }
            else if(watcherAI.WatcherHallway)
            {
                watcher.SetActive(true);
            }
            else
            {
                watcher.SetActive(false);
            }

            if (Clock >= CreepTime)
            {
                creep.SetActive(true);
            }
            else
            {
                creep.SetActive(false);
            }

            //Check for each hour, play clock sound each time.
            if (Clock == 0)
            {
                manager.Play("Clock 5", false);
            }
            else if (Clock == 240)
            {
                manager.Play("Clock 6", false);
            }
            else if (Clock == 480)
            {
                manager.Play("Clock 7", false);
            }
            else if (Clock == 720)
            {
                manager.Play("Clock 8", false);
            }
            else if (Clock == 960)
            {
                manager.Play("Clock 9", false);
            }
            else if (Clock == 1200)
            {
                manager.Play("Clock 10", false);
            }
            else if (Clock == 1440)
            {
                manager.Play("Clock 11", false);
            }
            else if (Clock == 1680)
            {
                manager.Play("Clock 12", false);
            }
            else if (Clock == 1920)
            {
                manager.Play("Clock 1", false);
            }
            else if (Clock == 2160)
            {
                manager.Play("Clock 2", false);
            }
            else if (Clock == 2400)
            {
                manager.Play("Clock 3", false);
            }
        }
    }

    public void adjustEndTime(float tta) //Takes time to adjust by, adjusts time by that amount - likely only neg values but takes either or
    {
        hourHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-0.25f * tta));
        minuteHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-3f * tta));
        endTime += tta;
    }

    public void SetWatcher(GameObject Input)
    {
        watcher = Input;
    }
    public void SetCreep(GameObject Input)
    {
        creep = Input;
    }
}
