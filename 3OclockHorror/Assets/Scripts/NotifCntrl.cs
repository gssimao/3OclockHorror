using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotifCntrl : MonoBehaviour
{
    //Serialized variables
    [SerializeField]
    GameObject Notification; //Holds the notification

    //Standard Variables
    float x = 0; //Float for tracking time

    public bool hasPlayed = false;
    AudioManager manager;
    [SerializeField]
    Text notifText;

    string defString = "New Journal Entry!";
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    private void OnEnable()
    {
        LeanTween.moveY(Notification, 100, 1.5f);
        if (manager != null)
        {
            //manager.Play("Writing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            if (manager != null && hasPlayed == false)
            {
                manager.Play("Writing", true);
                hasPlayed = true;
            }

            x += Time.deltaTime;
            if (x > 4)
            {
                resetCanvas();
                hasPlayed = false;
            }
        }
    }



    void resetCanvas()
    {
        x = 0;

        Vector3 orgPos = new Vector3(Notification.transform.position.x, -100f, Notification.transform.position.z);
        Notification.transform.position = orgPos;

        notifText.text = defString;

        this.gameObject.SetActive(false);
    }
}
