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
    public int TrapTime = 1680;
    public PlayerMovement player;
    public SanityManager sanity;
    private float sanityWait = 10;
    AudioManager manager;

    [SerializeField]
    public float Clock = 0;

    [SerializeField]
    GameObject minuteHand;

    [SerializeField]
    GameObject hourHand;

    [SerializeField]
    GameObject watcher;

    [SerializeField]
    GameObject creep;

    [SerializeField]
    GameObject TrapCtrl;

    public WatcherAI watcherAI;

    public bool hourIsPlaying= false;
    public float clipLength;

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

            if (Clock >= endTime) //Check if sys time is beyond end time, if so decrease sanity
            {
                sanityWait -= Time.deltaTime;
                if (sanityWait <= 0)
                {
                    sanity.ChangeSanity(-20);
                    sanityWait = 10f;
                }
            }
            else
            {
                hourHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-0.25f * Time.deltaTime));
                minuteHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-3f * Time.deltaTime));
            }
            if(sanity.sanityValue <= 0) //Check if the player has any sanity, if not end the game
            {
                SceneManager.LoadScene(2); //Load the Game Over scene
                Cursor.visible = true;
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

            if (Clock >= TrapTime)
            {
                TrapCtrl.SetActive(true);
            }
            else
            {
                TrapCtrl.SetActive(false);
            }

            //Check for each hour, play clock sound each time.
            if (Clock >= 0 && Clock <= 1  && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 5", false);
                clipLength = 27 + Clock;                //clipLength was added so that Clock Tick would not play while these bells are playing.
            }
            else if (Clock >= 240 && Clock <= 241 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 6", false);
                clipLength = 30 + Clock;
            }
            else if (Clock >= 480 && Clock <= 481 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 7", false);
                clipLength = 33 + Clock;
            }
            else if (Clock >= 720 && Clock <= 721 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 8", false);
                clipLength = 36 + Clock;
            }
            else if (Clock >= 960 && Clock <= 961 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 9", false);
                clipLength = 39 + Clock;
            }
            else if (Clock >= 1200 && Clock <= 1201 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 10", false);
                clipLength = 42 + Clock;
            }
            else if (Clock >= 1440 && Clock <= 1441 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 11", false);
                clipLength = 45 + Clock;
            }
            else if (Clock >= 1680 && Clock <= 1681 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 12", false);
                clipLength = 48 + Clock;
            }
            else if (Clock >= 1920 && Clock <= 1921 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 1", false);
                clipLength = 15 + Clock;
            }
            else if (Clock >= 2160 && Clock <= 2161 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 2", false);
                clipLength = 18 + Clock;
            }
            else if (Clock >= 2400 && Clock <= 2401 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 3", false);
                clipLength = 21 + Clock;
            }
            else if (hourIsPlaying == true && (clipLength - Clock) <= 0)
            {
                hourIsPlaying = false;
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
