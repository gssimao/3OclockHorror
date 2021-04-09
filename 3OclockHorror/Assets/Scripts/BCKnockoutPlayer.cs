using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCKnockoutPlayer : MonoBehaviour
{
    [SerializeField]
    timePassAnimator timePasser;
    [SerializeField]
    GameObject TimePasserCanv;

    public float x = 0;

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf == true)
        {
            x += Time.deltaTime;
            if(x > 2)
            {
                x = 0;
                TimePasserCanv.SetActive(true);
                timePasser.activateAnim();
                this.gameObject.SetActive(false);
            }
        }
    }
}
