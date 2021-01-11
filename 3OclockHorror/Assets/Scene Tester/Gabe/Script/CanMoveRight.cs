﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveRight : MonoBehaviour
{
    Collider2D ObjectCollider;
    public GameObject WalkScript;
    // Start is called before the first frame update
    void Start()
    {
        ObjectCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        WalkScript.GetComponent<PlayerMovement>().canMoveRight = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        WalkScript.GetComponent<PlayerMovement>().canMoveRight = true;
    }
}
