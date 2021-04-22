using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxEffect : MonoBehaviour
{
    public bool anxActive = false;
    public bool timeUp;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    SanityManager sanity;
    [SerializeField]
    GameObject eyeCanv;
    room curRoom;
    float tmr = 0;
    float dmgTmr = 30;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (anxActive)
        {
            if(player.myRoom != curRoom)
            {
                curRoom = player.myRoom;
                tmr = 0;
                dmgTmr = 30;
                timeUp = false;
            }
            else
            {
                tmr += Time.deltaTime;
                if(tmr >= 30)
                {
                    timeUp = true;

                    if (tmr >= dmgTmr)
                    {
                        dmgTmr += 1;
                        sanity.ChangeSanity(-5);
                    }
                }
            }
        }
    }

    public void activateAnxiety()
    {
        anxActive = true;
        eyeCanv.SetActive(true);
        FindObjectOfType<LightMatch>().ExpandMask();
    }
}
