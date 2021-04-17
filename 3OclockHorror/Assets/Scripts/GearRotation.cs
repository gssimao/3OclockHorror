using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    int[] GearPosition = new int[] { 0, 60, 120, 180, 240, 300 };
    public int movement = 0;
    AudioManager manager;

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
        if (/*uControls.UI.OtherSelect.triggered*/Input.GetMouseButtonUp(1)) //this should turn the big to the right
        {
            Debug.Log("Inside Right Click");
            movement = ControlBound(movement, true);
            LeanTween.rotateZ(gameObject, GearPosition[movement], .3f); // move gear
            manager.Play("Gear Turn", true);
        }
        if (/*uControls.UI.Select.triggered*/Input.GetMouseButtonUp(0)) //this should turn the big to the left
        {
            Debug.Log("Inside Left Click");
            movement = ControlBound(movement, false);
            LeanTween.rotateZ(gameObject, GearPosition[movement], .3f); // move gear
            manager.Play("Gear Turn", true);
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
