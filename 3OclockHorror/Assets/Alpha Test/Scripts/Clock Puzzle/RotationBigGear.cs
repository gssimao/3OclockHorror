using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBigGear : MonoBehaviour
{
    public GameObject medGear;
    public GameObject smallGear;
    AudioManager manager;

    int[] bigGearPosition = new int[] { 2, 25, 53, 81, 110, 138, 165, 193, 220, 248, 275, 305, 332};
    int[] medGearPosition = new int[] { 0, 60, 120, 180, 240, 300 };
    int[] smallGearPosition = new int[] {0, 120, 240}; // all z rotation location that this should turn to
    
    public int Bigmovement = 0;
    //medGear.GetComponent<RotationMedGear>().Medmovement       // this is a reference to an int variable in another gameobject, 
    // we need this reference to keep track of the position of the other gears. 
    //smallGear.GetComponent<RotationSmallGear>().Smallmovement;


    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    private void OnMouseOver()
    {
        
        if (Input.GetMouseButtonUp(1)) //this should turn the big to the right
        {
            manager.Play("Lock Turn");
            Bigmovement = ControlBound(Bigmovement, 13, true);
            medGear.GetComponent<RotationMedGear>().Medmovement = ControlBound(medGear.GetComponent<RotationMedGear>().Medmovement, 6, false);
            smallGear.GetComponent<RotationSmallGear>().Smallmovement = ControlBound(smallGear.GetComponent<RotationSmallGear>().Smallmovement, 3, false);
            
            LeanTween.rotateZ(gameObject, bigGearPosition[Bigmovement], 1); // move big gear
            LeanTween.rotateZ(medGear, medGearPosition[medGear.GetComponent<RotationMedGear>().Medmovement], 1); // move med gear
            LeanTween.rotateZ(smallGear, smallGearPosition[smallGear.GetComponent<RotationSmallGear>().Smallmovement], 1); // move small gear
            playSound();
        }
        if (Input.GetMouseButtonUp(0)) //this should turn the big to the left
        {
            Bigmovement = ControlBound(Bigmovement, 13, false);
            medGear.GetComponent<RotationMedGear>().Medmovement = ControlBound(medGear.GetComponent<RotationMedGear>().Medmovement, 6, true);
            smallGear.GetComponent<RotationSmallGear>().Smallmovement = ControlBound(smallGear.GetComponent<RotationSmallGear>().Smallmovement, 3, true);
            
            LeanTween.rotateZ(gameObject, bigGearPosition[Bigmovement], 1);
            LeanTween.rotateZ(medGear, medGearPosition[medGear.GetComponent<RotationMedGear>().Medmovement], 1); // move med gear
            LeanTween.rotateZ(smallGear, smallGearPosition[smallGear.GetComponent<RotationSmallGear>().Smallmovement], 1); // move small gear
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
                for (int i = 0; i < 3; i++)
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
                
                    if (moviment > 2)
                    {
                        moviment = 0;
                    }
                    if (moviment < 0)
                    {
                        moviment = 2;
                    }
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
            manager.Play("Lock Turn");
        }
    }
   
}

/*
notes and saved programming to rotate objects in their Z

   b m  s           b  m  s
b 1  3  5        b  R  L  R
m 1  2  3        m  L  R  L
s  1  2  1      s   R  L  R


    if()
    {
            Debug.Log("this is big gear");
            mPosDelta = Input.mousePosition - mPrevPos;
            this.transform.Rotate(transform.forward, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
            medGear.transform.Rotate(transform.forward, 3 * Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
            smallGear.transform.Rotate(transform.forward, 5 * Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
    }

        mPrevPos = Input.mousePosition;

 */