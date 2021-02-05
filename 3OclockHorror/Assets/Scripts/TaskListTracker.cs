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
    Text taskList;

    // Start is called before the first frame update
    void Start()
    {
        //Set base task to explore house
        taskList.text = "- Explore the house";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
