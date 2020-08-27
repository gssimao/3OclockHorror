using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMedGear : MonoBehaviour
{
    public GameObject BigGear;
    public GameObject smallGear;

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    private bool moveMedGear = false;

    private void OnMouseOver()
    {
        moveMedGear = true;
    }
    private void OnMouseExit()
    {
        moveMedGear = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && moveMedGear == true)
        {
            Debug.Log("this is med gear");
            mPosDelta = Input.mousePosition - mPrevPos;
            this.transform.Rotate(transform.forward, -2 * Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self); // this is med gear
            BigGear.transform.Rotate(transform.forward, Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
            smallGear.transform.Rotate(transform.forward, -3 * Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.Self);
        }
        mPrevPos = Input.mousePosition;
    }
}
