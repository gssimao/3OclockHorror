using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindCreepCntrl : MonoBehaviour
{
    bool plyrLocKnown; //Has the watcher seen the player? If so alert me so I can head there
    bool plyrSeen; //Have I seen the player? 
    //room myRoom

    //Public (editor assigned) Variables
    public GameObject player; //The player target for the Blind Creep to head towards / check against
    //Watcher reference as well perhaps?

    // Start is called before the first frame update
    void Start()
    {
        //Assign default states so Blind Creep starts normally
        plyrLocKnown = false;
        plyrSeen = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(myRoom = player.Room) This will check based on the room states for each - Would require a room variable, could maybe use colliders to help place rooms as well. Further out.
        {
            plrySeen = true;
        }
        */
    }

    public void activate()
    {
        gameObject.SetActive(true);
        //Other init, like where do we want them to spawn initially
    }
}
