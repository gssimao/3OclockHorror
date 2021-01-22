using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f; //Move speed

    public Rigidbody rb; //The rigidbody to act on

    Vector3 movement; //The actual movement

    // Update is called once per frame
    void Update()
    {
        // Register Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Move the object
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}