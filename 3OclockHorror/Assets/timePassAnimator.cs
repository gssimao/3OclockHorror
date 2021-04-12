using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePassAnimator : MonoBehaviour
{
    [SerializeField]
    GameObject referenceMinHand;
    [SerializeField]
    GameObject thisMinHand;

    [Space]

    [SerializeField]
    GameObject referenceHourHand;
    [SerializeField]
    GameObject thisHourHand;

    bool waitingToStart = false;
    bool animating = false;
    float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingToStart)
        {
            if (animating)
            {
                timePassed += Time.deltaTime;
                if (timePassed >= 2)
                {
                    animating = false;
                    waitingToStart = false;
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void UpdateHandPos()
    {
        thisMinHand.transform.rotation = referenceMinHand.transform.rotation;
        //thisHourHand.transform.rotation = referenceHourHand.transform.rotation;
        //thisHourHand.transform.rotation = new Quaternion(thisHourHand.transform.rotation.x, thisHourHand.transform.rotation.y, thisHourHand.transform.rotation.z - 175, 0f);
        Vector3 rotationVector = new Vector3(0, 0, referenceHourHand.transform.eulerAngles.z - 175);
        Quaternion rotation = Quaternion.Euler(rotationVector);
        thisHourHand.transform.rotation = rotation;
    }

    public void activateAnim()
    {
        this.gameObject.SetActive(true);

        LeanTween.rotate(thisHourHand, new Vector3(0, 0, referenceHourHand.transform.eulerAngles.z - 175), 1.5f);
        LeanTween.rotate(thisMinHand, referenceMinHand.transform.eulerAngles, 1.5f);

        Debug.LogError("Activating animation");

        animating = true;
        timePassed = 0f;
    }

    public void prepareAnimation()
    {
        UpdateHandPos();
        waitingToStart = true;

        Debug.LogError("Called prepareAnimation");

        this.gameObject.SetActive(false);
    }
}
