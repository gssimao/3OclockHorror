using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherHallway : MonoBehaviour
{
    [SerializeField]
    LightMatch plyMatch;
    [SerializeField]
    WatcherAI watcher;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    room eastHallway;

    bool toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.myRoom == eastHallway)
        {
            WatchHallwaySwitch();
        }
        else
        {
            WatchHallwaySwitch();
        }
    }

    void WatchHallwaySwitch()
    {
        if (!toggle)
        {
            plyMatch.enabled = false;
            watcher.WatcherHallway = true;
            toggle = true;
        }
        else
        {
            plyMatch.enabled = true;
            watcher.WatcherHallway = false;
            toggle = false;
        }

    }
}
