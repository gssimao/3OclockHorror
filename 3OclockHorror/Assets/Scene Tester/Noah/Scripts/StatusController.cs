using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    SanityManager sanity;
    [SerializeField]
    Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        sanity = FindObjectOfType<SanityManager>();
        if(statusText == null)
        {
            Debug.LogError("No status text to output to");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(statusText != null)
        {
            if(sanity.sanityValue >= 75)
            {
                statusText.text = "High level sanity text goes here";
            }
            else if(sanity.sanityValue >= 50)
            {
                statusText.text = "Status text for between 75 and 50 goes here";
            }
            else if(sanity.sanityValue >= 25)
            {
                statusText.text = "Status text for low sanity above 25 goes here";
            }
            else
            {
                statusText.text = "Lowest sanity status text goes here";
            }
        }
    }
}
