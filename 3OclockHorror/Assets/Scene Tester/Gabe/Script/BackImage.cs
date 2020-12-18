using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackImage : MonoBehaviour
{
    int[] Star = new int[] { 0, 90, 180, 270 }; // all z rotation location that this should turn to

    public int StarLocation = 0;
    public GameObject combination;
    Combination combine;
    private void Start()
    {
        combine = combination.GetComponent<Combination>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1)) //this should turn to the right
        {
            StarLocation++;
            if (StarLocation > 3)
            {
                StarLocation = 0;
            }

            LeanTween.rotateZ(gameObject, Star[StarLocation], 1);

            //combine.revelImage("Player1"); checking if the image is showing 
            combine.callImage();
            
        }
        if (Input.GetMouseButtonUp(0)) //this should turn to the left
        {
            StarLocation--;
            if (StarLocation < 0)
            {
                StarLocation = 3;
            }
            
            LeanTween.rotateZ(gameObject, Star[StarLocation], 1);
            combine.callImage();
        }
    }
}
