using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListTracker : MonoBehaviour
{
    //Logic flow:
    /**
     Explore the house
        - Photo
            - Coin
                - Bust

        - Daddy's note
    **/
    //Needed:
    /*
     * Task list reference
     * bools to track the stage the player is at
     * reference to popup notif
     */
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    room tuiRoom;
    [Space]

    [SerializeField]
    Text taskList;
    [SerializeField]
    GameObject orgTaskList;
    [SerializeField]
    GameObject dynTaskList;

    [SerializeField]
    GameObject alertCanv;
    [SerializeField]
    NotifCntrl notif;

    bool playerInHouse = false;

    // Update is called once per frame
    void Update()
    {
        if(!playerInHouse && player.myRoom != tuiRoom)
        {
            StartDynamTaskSys();
            playerInHouse = true;
        }   
    }

    public void StartDynamTaskSys()
    {
        //Set base task to explore house
        orgTaskList.SetActive(false);
        dynTaskList.SetActive(true);
        taskList.text = "- Explore the house";
        SendAlert();
    }

    public void SendAlert()
    {
        //This would be a potential option for triggering sound. Alternatively can also be associated with canvas.
        alertCanv.SetActive(true);
    }

    public bool updateList(string update)
    {
        bool rtrn = false;

        //Update task
        if(update == "")
        {
            Debug.Log("No task to add in.");
        }
        else
        {
            taskList.text += update;
            SendAlert();
            rtrn = true;
        }

        return rtrn;
    }

    public void DisplayMessage(string message)
    {
        if(message == "")
        {
            Debug.Log("No Message to display.");
        }
        else
        {
            notif.notifText.text = message;
            SendAlert();
        }
    }
}
