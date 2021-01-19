using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text TooltipText;
    private bool walked = false;
    public string startupMessage = "";
    public string Message;

    public GameObject player;

    public bool toolSwitch; //What type of tooltip? constant or prompt
    //Prompt Tooltip

    //Constant Tooltip

    float timer = 0;

    void Start()
    {
        TooltipText.text = startupMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer < 0)
        {
            timer = 0;
            Message = "";
        }

        if (startupMessage != "")
        {
            if (player.GetComponent<PlayerMovement>().walking == true && walked == false)
            {
                TooltipText.text = "";
                walked = true;
            }
        }

        if(Message == "The door is locked")
        {
            timer = 5;
            Message = "You need to find a key";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TooltipText.text = Message;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TooltipText.text = "";
    }
}
