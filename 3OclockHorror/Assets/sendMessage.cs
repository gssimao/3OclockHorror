using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendMessage : MonoBehaviour
{
    public Message message;
    public GameObject CallHouse;

    bool active = false;
    public bool instaPlay;
    public bool playOnlyOnce = true;
    public bool destroyMessage = false;

    private void Awake() // if true, it makes the message play instantly when the object attached is set to gameObject.SetActive(true);
    {
        if(instaPlay && playOnlyOnce)
        {
            playOnlyOnce = false;
            TriggerMessage();
        }
        else if (instaPlay)
        {
            TriggerMessage();
        }
    }

    public void TriggerMessage()
    {
        CallHouse.GetComponent<CallHouseText>().SetActivateAndGrabString(message);
        if(destroyMessage)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active)
        {
            TriggerMessage();
            active = true;
            Debug.Log("Triggered");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }
}

