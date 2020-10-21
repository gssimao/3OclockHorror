﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    public GameObject player;
    public GameObject Light;
    public SpriteMask LightMask;
    public Light flame; //Variable to that holds the light component of the game object

    public float interRange;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        flame = Light.GetComponent<Light>(); //gets the light component of the child of this game object and sets it to the variable
        flame.enabled = false;
        LightMask.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);

        if(dist <= interRange && Input.GetKeyDown("q"))
        {
            if (flame.isActiveAndEnabled == false)
            {
                CandleToggle(true);
                FindObjectOfType<AudioManager>().Play("Candle Light");
            }
            else
            {
                CandleToggle(false);
            }
        }
    }

    void OnDrawGizmos()// Draws a blue circle around the candle in the editor to help visualize the disance of the interactableRange
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, interRange);
    }

    public void CandleToggle(bool trigger)
    {
        if (trigger == false)
        {
            flame.enabled = false;
            LightMask.enabled = false;
        }
        else if(trigger == true)
        {
            flame.enabled = true;
            LightMask.enabled = true;
        }
    }
}
