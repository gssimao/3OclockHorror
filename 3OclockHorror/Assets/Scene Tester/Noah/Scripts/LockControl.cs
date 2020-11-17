using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockControl : MonoBehaviour, IPointerClickHandler
{
    public int movement = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        movement += -28; //A little funky as of yet
        if(movement < -360)
        {
            movement += 360;
        }
        LeanTween.rotateZ(gameObject, movement, 1); // move big gear
    }

}
