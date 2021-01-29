using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifCntrl : MonoBehaviour
{
    //Serialized variables
    [SerializeField]
    GameObject Notification; //Holds the notification

    //Standard Variables
    float x = 0; //Float for tracking time

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            x += Time.deltaTime;
            if (x > 4)
            {
                resetCanvas();
            }
        }
    }



    void resetCanvas()
    {
        x = 0;
        this.gameObject.SetActive(false);
    }
}
