using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullTurning : MonoBehaviour
{

    public Animator SkullRotation1;
    public Animator SkullRotation2;
    public Animator SkullRotation3;
    public Animator SkullRotation4;
    public int SkullPosition1 = 0;
    public int SkullPosition2 = 0;
    public int SkullPosition3 = 0;
    public int SkullPosition4 = 0;
    [Space]
    public pillarCntrl pillarDisplay;

    public CandleScript cn1;
    public CandleScript cn2;
    public CandleScript cn3;

    //Stage booleans
    bool stg1 = false;
    bool stg2 = false;
    bool stg3 = false;

    // Start is called before the first frame update
    void Start()
    {
        SkullPosition1 = Random.Range(0, 3);
        SkullPosition2 = Random.Range(0, 3);
        SkullPosition3 = Random.Range(0, 3);
        SkullPosition4 = Random.Range(0, 3);
        SkullRotation1.SetInteger("SkullPosition", SkullPosition1);
        SkullRotation2.SetInteger("SkullPosition", SkullPosition2);
        SkullRotation3.SetInteger("SkullPosition", SkullPosition3);
        SkullRotation4.SetInteger("SkullPosition", SkullPosition4);

        cn1.CandleToggle(true);
        cn2.CandleToggle(false);
        cn3.CandleToggle(false);
    }
    void Update()
    {
        /*
        if(SkullPosition1 == 2 && SkullPosition2 == 0 && SkullPosition3 == 2 && SkullPosition4 == 0)
        {
            Debug.Log("Solved");
        }
        */
        if (!stg3)
        {
            if (SkullPosition1 == 2 && SkullPosition2 == 0 && SkullPosition3 == 2 && SkullPosition4 == 0)
            {
                stg1 = true;
                pillarDisplay.updatePilar("stage1");
                Debug.Log("Stg 1 Complete");

                cn2.CandleToggle(true);
                cn1.CandleToggle(false);
            }
            if (SkullPosition1 == 1 && SkullPosition2 == 1 && SkullPosition3 == 3 && SkullPosition4 == 3 && stg1)
            {
                stg2 = true;
                pillarDisplay.updatePilar("stage2");
                Debug.Log("Stg 2 complete");

                cn2.CandleToggle(false);
                cn3.CandleToggle(true);
            }
            if (SkullPosition1 == 0 && SkullPosition2 == 2 && SkullPosition3 == 0 && SkullPosition4 == 2 && stg1 && stg2)
            {
                stg3 = true;
                pillarDisplay.updatePilar("stage3");
                Debug.Log("Stg 3 complete, locking puzzle");

                cn3.CandleToggle(false);
                this.GetComponent<SkullEnd>().OpenLeftEnding();
            }
        }
    }

    public void Turning1()
    {
        if (!stg3)
        { 
            SkullPosition1++;
            if (SkullPosition1 > 3)
            {
                SkullPosition1 = 0;
            }
            SkullRotation1.SetInteger("SkullPosition", SkullPosition1);
        }
    }
    public void Turning2()
    {
        if (!stg3)
        {
            SkullPosition2++;
            SkullPosition4++;
            if (SkullPosition2 > 3)
            {
                SkullPosition2 = 0;
            }
            if (SkullPosition4 > 3)
            {
                SkullPosition4 = 0;
            }
            SkullRotation2.SetInteger("SkullPosition", SkullPosition2);
            SkullRotation4.SetInteger("SkullPosition", SkullPosition4);
        }
    }
    public void Turning3()
    {
        if (!stg3)
        {
            SkullPosition1++;
            SkullPosition4++;
            if (SkullPosition1 > 3)
            {
                SkullPosition1 = 0;
            }
            if (SkullPosition4 > 3)
            {
                SkullPosition4 = 0;
            }
            SkullRotation1.SetInteger("SkullPosition", SkullPosition1);
            SkullRotation4.SetInteger("SkullPosition", SkullPosition4);
        }
    }
    public void Turning4()
    {
        if (!stg3)
        {
            SkullPosition1++;
            SkullPosition3++;
            SkullPosition4++;
            if (SkullPosition1 > 3)
            {
                SkullPosition1 = 0;
            }
            if (SkullPosition3 > 3)
            {
                SkullPosition3 = 0;
            }
            if (SkullPosition4 > 3)
            {
                SkullPosition4 = 0;
            }
            SkullRotation1.SetInteger("SkullPosition", SkullPosition1);
            SkullRotation3.SetInteger("SkullPosition", SkullPosition3);
            SkullRotation4.SetInteger("SkullPosition", SkullPosition4);
        }
    }
}
