using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBigGear : MonoBehaviour
{
    public GameObject medGear;
    public GameObject smallGear;

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    private bool moveBigGear = false;


    private void OnMouseOver()
    {
        moveBigGear = true;
    }
    private void OnMouseExit()
    {
        moveBigGear = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && moveBigGear == true)
        {
            Debug.Log("this is big gear");
            mPosDelta = Input.mousePosition - mPrevPos;
            this.transform.Rotate(transform.forward, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
            medGear.transform.Rotate(transform.forward, 3 * Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
            smallGear.transform.Rotate(transform.forward, 5 * Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
        }
        mPrevPos = Input.mousePosition;
    }
}
