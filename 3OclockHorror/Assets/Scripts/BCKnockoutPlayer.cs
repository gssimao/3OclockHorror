﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCKnockoutPlayer : MonoBehaviour
{
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
                this.gameObject.SetActive(false);
            }
        }
    }
}
