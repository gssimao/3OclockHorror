using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject invUI;
    public Animator anim;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input
        if (!invUI.activeSelf)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
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
    }

    void FixedUpdate()
    {
        // Movement

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
