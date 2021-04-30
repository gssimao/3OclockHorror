using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePassAnimator : MonoBehaviour
{
    [SerializeField]
    GameObject clock;

    [Space]
    [SerializeField]
    GameObject referenceMinHand;
    [SerializeField]
    GameObject thisMinHand;

    [Space]

    [SerializeField]
    GameObject referenceHourHand;
    [SerializeField]
    GameObject thisHourHand;

    [Space]
    [SerializeField]
    Animator plyAnim;
    [SerializeField]
    Animator Fade;

    bool waitingToStart = false;
    bool animating = false;
    float timePassed;
    float zdif;

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
                if(timePassed >= 0.76)
                {
                    LeanTween.rotate(thisMinHand, referenceMinHand.transform.rotation.eulerAngles, 0.75f);
                }
                if (timePassed >= 2)
                {
                    animating = false;
                    waitingToStart = false;
                    plyAnim.SetTrigger("wake");
                    this.gameObject.SetActive(false);
                }
            }
        }

        if(Fade.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Fade.gameObject.SetActive(false);

            this.gameObject.SetActive(false);
        }
    }

    public void UpdateHandPos()
    {
        thisMinHand.transform.rotation = referenceMinHand.transform.rotation;
        Debug.Log(thisMinHand.transform.rotation.eulerAngles);
        //thisHourHand.transform.rotation = referenceHourHand.transform.rotation;
        //thisHourHand.transform.rotation = new Quaternion(thisHourHand.transform.rotation.x, thisHourHand.transform.rotation.y, thisHourHand.transform.rotation.z - 175, 0f);
        Vector3 rotationVector = new Vector3(0, 0, referenceHourHand.transform.eulerAngles.z - 175);
        Quaternion rotation = Quaternion.Euler(rotationVector);
        thisHourHand.transform.rotation = rotation;
    }

    public void activateAnim()
    {
        this.gameObject.SetActive(true);

        Debug.Log(referenceMinHand.transform.rotation.eulerAngles);
        if (thisMinHand.transform.rotation.eulerAngles.z >= 0 && thisMinHand.transform.rotation.eulerAngles.z <= 180)
        {
            zdif = (thisMinHand.transform.rotation.eulerAngles.z - referenceMinHand.transform.eulerAngles.z);
        }
        else if(thisMinHand.transform.rotation.eulerAngles.z >= 180 && thisMinHand.transform.rotation.eulerAngles.z <= 360)
        {
            zdif = (thisMinHand.transform.rotation.eulerAngles.z + referenceMinHand.transform.eulerAngles.z);
        }

        LeanTween.rotate(thisHourHand, new Vector3(0, 0, referenceHourHand.transform.eulerAngles.z - 175), 1.5f);
        if (thisMinHand.transform.rotation.eulerAngles.z >= 180 && thisMinHand.transform.rotation.eulerAngles.z <= 270)
        {
            LeanTween.rotate(thisMinHand, new Vector3(0, 0, thisMinHand.transform.eulerAngles.z - zdif / 2), 0.75f);
        }
        else
        {
            LeanTween.rotate(thisMinHand, new Vector3(0, 0, thisMinHand.transform.eulerAngles.z + zdif / 2), 0.75f);
        }

        animating = true;
        timePassed = 0f;
    }

    public void prepareAnimation()
    {
        clock.SetActive(true);
        UpdateHandPos();
        waitingToStart = true;
        zdif = 0f;

        this.gameObject.SetActive(false);
    }

    void PlayWakeAnimation()
    {
        StartCoroutine(WakeUpAnimation());
    }
    IEnumerator WakeUpAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Fade.SetTrigger("fadeIn");

        plyAnim.SetTrigger("wake");
    }
}