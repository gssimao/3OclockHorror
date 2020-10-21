using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMatch : MonoBehaviour
{
    public Light match;
    public SpriteMask lightMask;
    public FlickLight fLight;

    bool timerLock = true;
    public float lifeTime;
    float ov;
    public float leanTime = 1;
    Vector3 small = new Vector3(0.3f, 0.3f, 0);
    Vector3 large = new Vector3(0.5f, 0.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        ov = lifeTime;
        match.enabled = false;
        lightMask.transform.localScale = small;
        fLight.spriteMask = lightMask;
        fLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && timerLock == true)
        {
            match.enabled = true;
            lightMask.transform.LeanScale(large, leanTime);
            fLight.enabled = true;
            timerLock = false;
            FindObjectOfType<AudioManager>().Play("Match Strike");
        }

        if(timerLock == false)
        {
            lifeTime -= Time.deltaTime;
        }

        if (lifeTime <= 0)
        {
            timerLock = true;
            match.enabled = false;
            lightMask.transform.LeanScale(small, leanTime);
            fLight.enabled = false;
            lifeTime = ov;
        }
    }
}
