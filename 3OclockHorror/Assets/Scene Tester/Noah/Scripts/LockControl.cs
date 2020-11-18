using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockControl : MonoBehaviour, IPointerClickHandler
{
    public int movement = 0;
    public string numeral = "I";

    public void OnPointerClick(PointerEventData eventData)
    {
        SetMovement(-36);

        LeanTween.rotateZ(gameObject, movement, 1); // move big gear

        UpdateNumeral();
    }

    public void SetMovement(int mod)
    {
        movement += mod;
        if(movement == 360)
        {
            movement = 0;
        }
        else if(movement < -360)
        {
            movement += 360;
        }
    }

    public void UpdateNumeral()
    {
        switch (numeral)
        {
            case "I":
                numeral = "II";
                break;
            case "II":
                numeral = "III";
                break;
            case "III":
                numeral = "IV";
                break;
            case "IV":
                numeral = "V";
                break;
            case "V":
                numeral = "VI";
                break;
            case "VI":
                numeral = "VII";
                break;
            case "VII":
                numeral = "VIII";
                break;
            case "VIII":
                numeral = "IX";
                break;
            case "IX":
                numeral = "X";
                break;
            case "X":
                numeral = "I";
                break;
        }
    }
}
