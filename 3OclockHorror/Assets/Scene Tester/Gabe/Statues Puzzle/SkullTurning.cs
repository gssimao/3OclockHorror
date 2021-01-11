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

    // Start is called before the first frame update
    void Start()
    {
        SkullPosition1 = Random.Range(0, 4);
        SkullPosition2 = Random.Range(0, 3);
        SkullPosition3 = Random.Range(0, 4);
        SkullPosition4 = Random.Range(0, 3);
        SkullRotation1.SetInteger("SkullPosition", SkullPosition1);
        SkullRotation2.SetInteger("SkullPosition", SkullPosition2);
        SkullRotation3.SetInteger("SkullPosition", SkullPosition3);
        SkullRotation4.SetInteger("SkullPosition", SkullPosition4);
    }
    void Update()
    {
        if(SkullPosition1 == 2 && SkullPosition2 == 0 && SkullPosition3 == 2 && SkullPosition4 == 0)
        {
            Debug.Log("Solved");
        }
    }

    public void Turning1()
    {
        /*SkullPosition1++;
        if(SkullPosition1 > 3)
        {
            SkullPosition1 = 0;
        }
        SkullRotation1.SetInteger("SkullPosition", SkullPosition1);*/
    }
    public void Turning2()
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
    public void Turning3()
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
    public void Turning4()
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
