using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMatch : MonoBehaviour
{

    public Light match;

    bool timerLock = true;
    public float lifeTime;
    float ov;
    // Start is called before the first frame update
    void Start()
    {
        ov = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && timerLock == true)
        {
            match.enabled = true;
            FindObjectOfType<AudioManager>().Play("Match Strike");
            timerLock = false;
        }

        if(timerLock == false)
        {
            lifeTime -= Time.deltaTime;
        }

        if (lifeTime <= 0)
        {
            timerLock = true;
            match.enabled = false;
            lifeTime = ov;
        }
    }
}
