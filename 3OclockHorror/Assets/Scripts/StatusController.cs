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
            if(sanity.sanityValue > 80)
            {
                statusText.text = "Feeling healthy, I have heard what this house does to the minds of people. Keeping this journal will help me preserve my sanity.";
            }
            else if(sanity.sanityValue > 60)
            {
                statusText.text = "I am starting to feel dizzy, not too bad though. I wonder how much worse it will get.";
            }
            else if(sanity.sanityValue > 40)
            {
                statusText.text = "Starting to feel nauseous the house is takng a toll on my mind.";
            }
            else if(sanity.sanityValue > 20)
            {
                statusText.text = "Seeng things, rooms warping hed throbbing. Cant last much longer.";
            }
            else
            {
                statusText.text = "thbreating inheavg mind linveag rnnuing yawa pasceing";
            }
        }
    }
}
