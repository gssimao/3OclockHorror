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

    public bool toolSwitch; //What type of tooltip? constant or prompt
    //Prompt Tooltip

    //Constant Tooltip

    void Start()
    {
        TooltipText.text = startupMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player2").GetComponent<PlayerMovement>().walking == true && walked == false)
        {
            TooltipText.text = "";
            walked = true;
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
