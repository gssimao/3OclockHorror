using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photoTracker : MonoBehaviour
{
    //Just a really quick script to check if the 6 photos are all active and if a notification has been sent.
    bool notifSent = false;

    [SerializeField]
    List<GameObject> photos;
    [SerializeField]
    TaskListTracker taskManager;

    // Update is called once per frame
    void Update()
    {
        if (!notifSent)
        {
            bool photosActive = true;
            foreach(GameObject photo in photos)
            {
                if (!photo.activeSelf)
                {
                    photosActive = false;
                }
            }
            if (photosActive)
            {
                taskManager.updateList("\n -The photos appear to have some order to them, what could it be?");
                notifSent = true;
            }
        }
    }
}
