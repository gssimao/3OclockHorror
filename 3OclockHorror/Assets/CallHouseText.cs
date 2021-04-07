using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallHouseText : MonoBehaviour
{
    public GameObject MainSystem;
    int dialogProgress = 0;
    private Writer textWriter;
    public Text dialog;
    public AudioSource typewriter;
    public AudioSource DoneWriting;
    private Writer.TextWriterSingle textWriterSingle;



    private void Awake()
    {
        MainSystem.SetActive(false);

    }

    public void WriteString(string message) // this is where the calls will happen
    {
       
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
    public void ShowNewMessage()
    {
        if(textWriterSingle != null && textWriterSingle.isActive())
        {
            // the writer is active
            textWriterSingle.WriteAndDestroy();
        }
        else
        {
            string[] messageArray = new string[]
            {
            "first message",
            "Second message",
            "Third message",
            "4 message",
            "5 message"
            };
            string message = messageArray[Random.Range(0, messageArray.Length)];
            StartTypingSound();
            textWriterSingle = Writer.AddWriter_Static(dialog, message, .1f, true, true, StopTypingSound);
        }
        

        

        /*if (messageArray.Length == dialogProgress)
        {
            dialogProgress = 0;
        }
        else
        {
            dialogProgress++;
        }

        string message = messageArray[dialogProgress];
        Writer.AddWriter_Static(dialog, message, .2f, true);
        return dialogProgress;
        */
    }
}
