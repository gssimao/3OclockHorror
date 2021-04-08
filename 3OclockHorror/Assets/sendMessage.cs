using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendMessage : MonoBehaviour
{
    public Message message;
    public GameObject CallHouse;

    bool active = false;

    public void TriggerMessage()
    {
        CallHouse.GetComponent<CallHouseText>().SetActivateAndGrabString(message);
        //CallHouse.GetComponent<CallHouseText>().ShowNewMessage();
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

