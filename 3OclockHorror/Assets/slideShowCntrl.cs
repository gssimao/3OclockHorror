using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideShowCntrl : MonoBehaviour
{
    [SerializeField]
    GameObject imageone;
    [SerializeField]
    GameObject imagetwo;

    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 2)
        {
            imageone.SetActive(false);
            imagetwo.SetActive(true);
        }
        if(time > 4)
        {
            this.gameObject.SetActive(false);
        }
    }
}
