using System.Collections;
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

    [Space]
    [SerializeField]
    Tooltip popup;

    public WatcherAI watcherAI;

    public bool hourIsPlaying= false;
    public float clipLength;

    // Start is called before the first frame update 
    void Start()
    {
        endTime = 2400.0f; //set endtime, to however long we want it to run 
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
                hourHand.GetComponent<RectTransform>().Rotate(0f, 0f, ((-0.25f * Time.deltaTime)/2));
                minuteHand.GetComponent<RectTransform>().Rotate(0f, 0f, ((-3f * Time.deltaTime)/2));
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

                popup.UpdateTooltipMessage("5PM: 10 hours remain.");
            }
            else if (Clock >= 240 && Clock <= 242 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 6", false);
                clipLength = 30 + Clock;

                popup.UpdateTooltipMessage("6PM: 9 hours remain.");
            }
            else if (Clock >= 480 && Clock <= 482 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 7", false);
                clipLength = 33 + Clock;

                popup.UpdateTooltipMessage("7PM: 8 hours remain.");
            }
            else if (Clock >= 720 && Clock <= 722 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 8", false);
                clipLength = 36 + Clock;

                popup.UpdateTooltipMessage("8PM: 7 hours remain.");
            }
            else if (Clock >= 960 && Clock <= 962 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 9", false);
                clipLength = 39 + Clock;

                popup.UpdateTooltipMessage("9PM: 6 hours remain.");
            }
            else if (Clock >= 1200 && Clock <= 1202 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 10", false);
                clipLength = 42 + Clock;

                popup.UpdateTooltipMessage("10PM: 5 hours remain.");
            }
            else if (Clock >= 1440 && Clock <= 1442 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 11", false);
                clipLength = 45 + Clock;

                popup.UpdateTooltipMessage("11PM: 4 hours remain.");
            }
            else if (Clock >= 1680 && Clock <= 1682 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 12", false);
                clipLength = 48 + Clock;

                popup.UpdateTooltipMessage("12AM: 3 hours remain.");
            }
            else if (Clock >= 1920 && Clock <= 1922 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 1", false);
                clipLength = 15 + Clock;

                popup.UpdateTooltipMessage("1AM: 2 hours remain.");
            }
            else if (Clock >= 2160 && Clock <= 2162 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 2", false);
                clipLength = 18 + Clock;

                popup.UpdateTooltipMessage("22AM: 1 hours remain.");
            }
            else if (Clock >= 2400 && Clock <= 2402 && manager != null && hourIsPlaying == false)
            {
                hourIsPlaying = true;
                manager.Play("Clock 3", false);
                clipLength = 21 + Clock;

                popup.UpdateTooltipMessage("3AM: Time's Up");
            }
            else if (hourIsPlaying == true && Clock > clipLength)
            {
                hourIsPlaying = false;
            }
        }
    }

    public void adjustTime(float tta) //Takes time to adjust by, adjusts time by that amount - likely only neg values but takes either or
    {
        hourHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-0.25f * (tta/2)));
        minuteHand.GetComponent<RectTransform>().Rotate(0f, 0f, (-3f * (tta/2)));
        Clock += tta;
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
