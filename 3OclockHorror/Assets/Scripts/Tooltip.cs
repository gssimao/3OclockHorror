using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    Text TooltipText;
    [SerializeField]
    GameObject player;
    [SerializeField]
    CanvasGroup cnvGroup;

    public static string Message = "";

    //OnStartup Message
    public bool masterSwitch = false;
    public string startupMessage = "";

    [SerializeField]
    float timer = 0;
    [SerializeField]
    float alottedTime = 2.5f;

    
    void Start()
    {
        //timer = alottedTime;
        if (masterSwitch == true)
        {
            TooltipText.text = "";
            TooltipText.text = startupMessage;
        }
        else
        {
            cnvGroup.alpha = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*float dist = Vector3.Distance(player.transform.position, transform.position); //Get the position of player
        if(dist <= 0.4f)
        {
            TooltipText.text = Message;
            timer = 1;
            cnvGroup.alpha = 1;
        }*/
        if(Message != "")
        {
            UpdateTooltipMessage(Message);
            Debug.Log(Message);
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            timer = 0;
            cnvGroup.alpha -= Time.deltaTime;
            if (cnvGroup.alpha <= 0)
            {
                cnvGroup.alpha = 0;
                TooltipText.text = "";
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        TooltipText.text = PromptMessage;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TooltipText.text = "";
    }*/

    void UpdateTooltipMessage(string update)//Type Tooltip.UpdateToolTipMessage("string goes here"), to change tooltip message from anywhere
    {
        TooltipText.text = update;
        timer = alottedTime;
        cnvGroup.alpha = 1;
        Message = "";
    }
}