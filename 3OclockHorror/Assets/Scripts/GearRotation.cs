using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    int[] GearPosition = new int[] { 0, 60, 120, 180, 240, 300 };
    public int movement = 0;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1)) //this should turn the big to the right
        {
            movement = ControlBound(movement, true);
            LeanTween.rotateZ(gameObject, GearPosition[movement], 1); // move gear
        }
        if (Input.GetMouseButtonUp(0)) //this should turn the big to the left
        {
            movement = ControlBound(movement, false);
            LeanTween.rotateZ(gameObject, GearPosition[movement], 1); // move gear
        }
    }
    private int ControlBound(int moviment, bool addOrSubtract) // the bool should tell if the we are adding or subtracting. True is adding
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
        return moviment;
    }
}
