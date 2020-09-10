﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workbench_cntrl : MonoBehaviour
{
    public GameObject player;
    public GameObject timeUI; //Time UI, used to deactivate for screenclutter.
    public GameObject myWorkspace; //The canvas for this specific workbench to work with.

    invUI invUI;
    bool active;

    //public GameObject ePrompt; //Prompt to press E - Will likely depreciate beyond alpha
    private void Start()
    {
        invUI = player.GetComponent<invUI>();
    }


    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position); //Get the position of player
        if(dist <= 1.5f) //If the player is in range
        {
            if (Input.GetKeyDown("e"))
            {
                if (!active) 
                {
                    invUI.activateUI();
                    myWorkspace.SetActive(true);

                    timeUI.SetActive(false);
                    active = true;
                }
                else
                {
                    myWorkspace.SetActive(false);
                    invUI.deactivateUI();

                    timeUI.SetActive(true);
                    active = false;
                }
            }
        }
    }
}
