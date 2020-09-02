using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workbench_cntrl : MonoBehaviour
{
    public GameObject player;
    public GameObject timeUI; //Time UI, used to deactivate for screenclutter.
    public GameObject myWorkspace; //The canvas for this specific workbench to work with.
    public GameObject ePrompt; //Prompt to press E - Will likely depreciate beyond alpha

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position); //Get the position of player
        if(dist <= 1.5f) //If the player is in range
        { 
            ePrompt.SetActive(true); //Show the prompt

            if (Input.GetKeyDown("e")) //if E is pressed
            {
                timeUI.SetActive(false); //Change the active UI around
                myWorkspace.SetActive(true);
            }
        }
        else
        {
            ePrompt.SetActive(false); //If out of range, deactivate the prompt.
        }
    }
}
