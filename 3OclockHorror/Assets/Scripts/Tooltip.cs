using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text TooltipText;
    private bool walked = false;
    public GameObject player;

    //Prompt Message
    public string PromptMessage;

    //Timed Message
    public string TimedMessage;

    //OnStartup Message
    public bool masterSwitch = false;
    public string startupMessage = "";

    public float timer = 0;

    void Start()
    {
        if (masterSwitch == true)
        {
            TooltipText.text = "";
            TooltipText.text = startupMessage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TimedMessage != "")
        {
            TooltipText.text = TimedMessage;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer < 0)
        {
            timer = 0;
            TimedMessage = "";
            TooltipText.text = "";
        }

        if (startupMessage != "")
        {
            if (player.GetComponent<PlayerMovement>().walking == true && walked == false)
            {
                TooltipText.text = "Press E to open the Journal. Use the arrows on the pages to navigate.";
                walked = true;
            }
        }

        if(TooltipText.text != "" && timer == 0)
        {
            timer = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TooltipText.text = PromptMessage;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TooltipText.text = "";
    }
}
