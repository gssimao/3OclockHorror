﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMatch : MonoBehaviour
{
    public Light match;
    public SpriteMask lightMask;
    public FlickLight fLight;
    public GameObject lightEffect;

    bool timerLock = true;
    bool lightOn = false;
    public float lifeTime;
    float ov;
    public float leanTime = 1;
    Vector3 small = new Vector3(0.3f, 0.3f, 0);
    Vector3 large = new Vector3(0.5f, 0.5f, 0);
    AudioManager manager;

    // Start is called before the first frame update
    void Start()
    {
        ov = lifeTime;
        match.enabled = false;
        lightMask.transform.localScale = small;
        fLight.spriteMask = lightMask;
        fLight.enabled = false;
        lightEffect.SetActive(false);
        Light(true);
        //Light(false);
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && timerLock == true)
        {
            Light();

            if (manager != null)
            {
                manager.Play("Match Strike", true);
            }
        }

        if(timerLock == false)
        {
            lifeTime -= Time.deltaTime;
        }

        if (lifeTime <= 0)
        {
            Light();
        }
    }

    void Light()
    {
        if (!lightOn)
        {
            match.enabled = true;
            lightMask.transform.LeanScale(large, leanTime);
            fLight.enabled = true;
            timerLock = false;
            lightEffect.SetActive(true);

            lightOn = true;
        }
        else
        {
            timerLock = true;
            match.enabled = false;
            lightMask.transform.LeanScale(small, leanTime);
            fLight.enabled = false;
            lifeTime = ov;
            lightEffect.SetActive(false);

            lightOn = false;
        }
    }
    public void Light(bool toggle)
    {
        if (toggle)
        {
            match.enabled = true;
            lightMask.transform.LeanScale(large, leanTime);
            fLight.enabled = true;
            timerLock = false;
            lightEffect.SetActive(true);

            lightOn = true;
        }
        else
        {
            timerLock = true;
            match.enabled = false;
            lightMask.transform.LeanScale(small, leanTime);
            fLight.enabled = false;
            lifeTime = ov;
            lightEffect.SetActive(false);

            lightOn = false;
        }
    }

    public void TurnOffLight(bool toggle)
    {
        if(toggle)
        {
            match.gameObject.SetActive(true);
        }
        else
        {
            match.gameObject.SetActive(false);
        }
    }
}
