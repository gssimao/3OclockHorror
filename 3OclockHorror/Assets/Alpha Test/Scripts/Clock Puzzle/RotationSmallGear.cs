using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSmallGear : MonoBehaviour
{
    public GameObject BigGear;
    public GameObject MedGear;
    AudioManager manager;

    int[] bigGearPosition = new int[] { 2, 25, 53, 81, 110, 138, 165, 193, 220, 248, 275, 305, 332 };
    int[] medGearPosition = new int[] { 0, 60, 120, 180, 240, 300 };
    int[] smallGearPosition = new int[] { 0, 120, 240 }; // all z rotation location that this should turn to

    public int Smallmovement = 0;

    UniversalControls uControls;
    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();
    }
    private void OnDisable()
    {
        uControls.Disable();
    }
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    private void OnMouseOver()
    {
        if (uControls.UI.Select.triggered/*Input.GetMouseButtonUp(1)*/) //this should turn the big to the right
        {
            BigGear.GetComponent<RotationBigGear>().Bigmovement = ControlBound(BigGear.GetComponent<RotationBigGear>().Bigmovement, 13, true);
            MedGear.GetComponent<RotationMedGear>().Medmovement = ControlBound(MedGear.GetComponent<RotationMedGear>().Medmovement, 6, false);
            Smallmovement = ControlBound(Smallmovement, 3, true);

            LeanTween.rotateZ(BigGear, bigGearPosition[BigGear.GetComponent<RotationBigGear>().Bigmovement], .3f); // move big gear
            LeanTween.rotateZ(MedGear, medGearPosition[MedGear.GetComponent<RotationMedGear>().Medmovement], .3f); // move med gear
            LeanTween.rotateZ(gameObject, smallGearPosition[Smallmovement], .3f); // move small gear
            playSound();
        }
        if (uControls.UI.OtherSelect.triggered/*Input.GetMouseButtonUp(0)*/) //this should turn the big to the left
        {
            BigGear.GetComponent<RotationBigGear>().Bigmovement = ControlBound(BigGear.GetComponent<RotationBigGear>().Bigmovement, 13, false);
            MedGear.GetComponent<RotationMedGear>().Medmovement = ControlBound(MedGear.GetComponent<RotationMedGear>().Medmovement, 6, true);
            Smallmovement = ControlBound(Smallmovement, 3, false);

            LeanTween.rotateZ(BigGear, bigGearPosition[BigGear.GetComponent<RotationBigGear>().Bigmovement], .3f);
            LeanTween.rotateZ(MedGear, medGearPosition[MedGear.GetComponent<RotationMedGear>().Medmovement], .3f); // move med gear
            LeanTween.rotateZ(gameObject, smallGearPosition[Smallmovement], .3f); // move small gear
            playSound();
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

    void playSound()
    {
        if (manager != null)
        {
            manager.Play("Lock Turn", true);
        }
    }
}

/*
b m  s           b  m  s
b 1  3  5        b  R  L  R
m 1  2  3        m  L  R  L
s  1  2  1      s   R  L  R
*/
