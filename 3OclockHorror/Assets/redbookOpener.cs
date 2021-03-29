﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redbookOpener : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bookCanv;
    [Space]
    [SerializeField]
    invInput Listener;
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        if(dist < 0.25)
        {
            Listener.isFocus = false;
            if (Input.GetKeyDown("e") && !bookCanv.activeSelf)
            {
                bookCanv.SetActive(true);
            }
        }
    }
}
