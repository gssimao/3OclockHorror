using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockControl : MonoBehaviour, IPointerClickHandler
{
    public int movement = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
