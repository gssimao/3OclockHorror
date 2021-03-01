﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveKey : MonoBehaviour
{
    [SerializeField]
    Inventory plyInv;
    [SerializeField]
    Item key;
    [SerializeField]
    Tooltip tooltipScript;
    [SerializeField]
    GameObject invCanv;
    [SerializeField]
    invInput Listener;
    public GameObject KeyPopUp;
    AudioManager manager;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, plyInv.transform.position);

        if (dist <= 0.6f)
        {
            Listener.enabled = false;

            if (Input.GetKeyDown("e"))
            {
                if (manager != null)
                {
                    manager.Play("Key pickup", true);
                }
                KeyPopUp.SetActive(true);
                invCanv.SetActive(true);
                plyInv.AddItem(key);
                invCanv.SetActive(false);
                //tooltipScript.TimedMessage = "There's a key in the pocket";
            }
        }

        Listener.enabled = true;
    }
}
