﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject invUI;
    public Animator anim;
    public room myRoom;
    public Rigidbody2D rb;
    public bool walking;
    public Camera camera;
    public Vector2 movement;
    public bool isPlaying = false; //For playing footsteps

    void Start()
    {
        invUI.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        if (!invUI.activeSelf)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }

        if(movement.x < 0)
        {
            anim.SetBool("walkingLeft", true);
        }
        else
        {
            anim.SetBool("walkingLeft", false);
        }

        if (movement.x > 0)
        {
            anim.SetBool("walkingRight", true);
        }
        else
        {
            anim.SetBool("walkingRight", false);
        }

        if (movement.y < 0)
        {
            anim.SetBool("walkingForwards", true);
        }
        else
        {
            anim.SetBool("walkingForwards", false);
        }

        if (movement.y > 0)
        {
            anim.SetBool("walkingBackwards", true);
        }
        else
        {
            anim.SetBool("walkingBackwards", false);
        }

        if(movement.x != 0 || movement.y != 0)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        if(walking == true) //Footstep sound effects
        {
            if (isPlaying == false)
            {
                FindObjectOfType<AudioManager>().Play("Player Footsteps");
            }
            else FindObjectOfType<AudioManager>().Stop("Player Footsteps");
        }
    }

    void FixedUpdate()
    {
        // Movement

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        camera.transform.position = myRoom.getCameraPoint().transform.position;
    }
}
