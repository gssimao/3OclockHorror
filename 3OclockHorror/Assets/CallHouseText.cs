using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallHouseText : MonoBehaviour
{
    int dialogProgress = 0;
    private Queue<string> messageQueue;
    private Writer textWriter;
    public Text TextUi;
    public AudioSource typewriter;
    public AudioSource DoneWriting;
    private Writer.TextWriterSingle textWriterSingle;
    public Image blackTop;
    public Button Button;
    [SerializeField]
    //public string[] messageArray = new string[] { }; //this is for testing


    private void Awake()
    {
        messageQueue = new Queue<string>();

        Color newColor = blackTop.color;
        newColor.a = 0;                 // changing Alpha to zero
        blackTop.color = newColor;      // starting transparent

        //TextUi.text = ""; // setting so dialog is equalt o nothing at the start
        Button.interactable = false;//turn off the button



       /* //ShowNewMessage(); //this is for testing
        string[] localmessageArray = new string[] {"this is 1 message", "2 this is a second test", "3 test again again", "4 test test test"};
        
        SetActivateAndGrabString(localmessageArray);
        ShowNewMessage();*/
    }


    public void ShowNewMessage()
    {
        //string[]
        string message; //local string that will pass on the message to the writer
        if(textWriterSingle != null && textWriterSingle.isActive())
        {
            // the writer is active and currently writting
            textWriterSingle.WriteAndDestroy();
        }
        else
        {
            if (messageQueue.Count == 0)
            {
                CompleteAndTurnOff();
                Debug.Log("no more text bro");


            } 
            else {
                message = messageQueue.Dequeue();
                StartTypingSound();
                textWriterSingle = Writer.AddWriter_Static(TextUi, message, .1f, true, true, StopTypingSound);
            }
        }
    }

    public void SetActivateAndGrabString(Message dialogue)
    {
        
        Button.interactable = true;
        messageQueue.Clear();
        
        foreach (string message in dialogue.messagesToWrite)
        {
            messageQueue.Enqueue(message);
           
        }
        
        ShowNewMessage();
        //LeanTween.alpha(blackTop.gameObject, 1f, .7f);
    }
/*    public void DisplayNextMessage()
    {
        if (messages.Count == 0)
        {
            CompleteAndTurnOff();
            return;
        }
        string Currentmessage = messages.Dequeue();
    }*/
    private void CompleteAndTurnOff()
    {
        dialogProgress = 0;
        TextUi.text = "";
        Button.interactable = false;
        //fade out with leanTween
        LeanTween.value(blackTop.gameObject, 1f, 0, .5f).setOnUpdate((float val) =>
        {
            Image BlackTop = blackTop;
            Color newColor = BlackTop.color;
            newColor.a = val; // changing Alpha
            BlackTop.color = newColor;
        });
    }
    private void StartTypingSound()
    {
        typewriter.Play();
    }
    private void StopTypingSound()
    {
        typewriter.Stop();
        DoneWriting.PlayOneShot(DoneWriting.clip);
    }
}
