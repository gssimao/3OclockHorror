using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSmallGear : MonoBehaviour
{
    public GameObject BigGear;
    public GameObject MedGear;

    int[] bigGearPosition = new int[] { 2, 25, 53, 81, 110, 138, 165, 193, 220, 248, 275, 305, 332 };
    int[] medGearPosition = new int[] { 0, 60, 120, 180, 240, 300 };
    int[] smallGearPosition = new int[] { 0, 120, 240 }; // all z rotation location that this should turn to

    public int Smallmovement = 0;



    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1)) //this should turn the big to the right
        {
            BigGear.GetComponent<RotationBigGear>().Bigmovement = ControlBound(BigGear.GetComponent<RotationBigGear>().Bigmovement, 13, true);
            MedGear.GetComponent<RotationMedGear>().Medmovement = ControlBound(MedGear.GetComponent<RotationMedGear>().Medmovement, 6, false);
            Smallmovement = ControlBound(Smallmovement, 3, true);

            LeanTween.rotateZ(BigGear, bigGearPosition[BigGear.GetComponent<RotationBigGear>().Bigmovement], 1); // move big gear
            LeanTween.rotateZ(MedGear, medGearPosition[MedGear.GetComponent<RotationMedGear>().Medmovement], 1); // move med gear
            LeanTween.rotateZ(gameObject, smallGearPosition[Smallmovement], 1); // move small gear
        }
        if (Input.GetMouseButtonUp(0)) //this should turn the big to the left
        {
            BigGear.GetComponent<RotationBigGear>().Bigmovement = ControlBound(BigGear.GetComponent<RotationBigGear>().Bigmovement, 13, false);
            MedGear.GetComponent<RotationMedGear>().Medmovement = ControlBound(MedGear.GetComponent<RotationMedGear>().Medmovement, 6, true);
            Smallmovement = ControlBound(Smallmovement, 3, false);

            LeanTween.rotateZ(BigGear, bigGearPosition[BigGear.GetComponent<RotationBigGear>().Bigmovement], 1);
            LeanTween.rotateZ(MedGear, medGearPosition[MedGear.GetComponent<RotationMedGear>().Medmovement], 1); // move med gear
            LeanTween.rotateZ(gameObject, smallGearPosition[Smallmovement], 1); // move small gear
        }
    }


    private int ControlBound(int moviment, int size, bool addOrSubtract) // the bool should tell if the we are adding or subtracting. True is adding
    {
        switch (size)
        {
            case 13:
                if (addOrSubtract == true)
                {
                    moviment++;
                }
                if (addOrSubtract == false)
                {
                    moviment--;
                }
                if (moviment > 12)
                {
                    moviment = 0;
                }
                if (moviment < 0)
                {
                    moviment = 12;
                }
                break;
            case 6:
                for (int i = 0; i < 2; i++)
                {
                    if (addOrSubtract == true)
                    {
                        moviment++;
                    }
                    if (addOrSubtract == false)
                    {
                        moviment--;
                    }
                    if (moviment > 5)
                    {
                        moviment = 0;
                    }
                    if (moviment < 0)
                    {
                        moviment = 5;
                    }
                }
                break;
            case 3:
               if (addOrSubtract == true)
               {
                   moviment++;
               }
               if (addOrSubtract == false)
               {
                   moviment--;
               }
               if (moviment > 2)
               {
                   moviment = 0;
               }
               if (moviment < 0)
               {
                   moviment = 2;
               }
                break;
            default:
                Debug.Log("The size is incorrect put either 3, 6, or 13 for size");
                break;
        }
        return moviment;
    }
}

/*
b m  s           b  m  s
b 1  3  5        b  R  L  R
m 1  2  3        m  L  R  L
s  1  2  1      s   R  L  R
*/
