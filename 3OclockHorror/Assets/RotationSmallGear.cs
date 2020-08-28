using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSmallGear : MonoBehaviour
{
    public GameObject BigGear;
    public GameObject MedGear;

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    private bool moveSmallGear = false;
    private void OnMouseOver()
    {
        moveSmallGear = true;
    }
    private void OnMouseExit()
    {
        moveSmallGear = false;
    }


    void Update()
    {
        if (Input.GetMouseButton(0) && moveSmallGear == true)
        {
            Debug.Log("this is small gear");
            mPosDelta = Input.mousePosition - mPrevPos;
            this.transform.Rotate(transform.forward, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
            BigGear.transform.Rotate(transform.forward, Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
            MedGear.transform.Rotate(transform.forward, 2 * Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
        }
        mPrevPos = Input.mousePosition;
    }
}
