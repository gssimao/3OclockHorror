using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profaneEffect : MonoBehaviour
{
    [SerializeField]
    bool active = false;
    [SerializeField]
    clockCntrl clock;
    [SerializeField]
    SanityManager sanity;

    bool activated;

    // Update is called once per frame
    void Update()
    {
        if (active && !activated)
        {
            activateProfane();
        }
    }

    public void activateProfane()
    {
        clock.activateProfane();
        float sanChange = 20 - sanity.sanityValue;
        sanity.ChangeSanity(sanChange);
        activated = true;
        active = true;
    }
}
