using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractibleTrigger : MonoBehaviour
{
    public static Action DisableJournal = delegate { };
    public static Action EnableJournal = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactible"))
        {
            Tooltip.Message = "E";
            DisableJournal();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactible"))
        {
            Tooltip.Message= "";
            EnableJournal();
        }
    }
}
