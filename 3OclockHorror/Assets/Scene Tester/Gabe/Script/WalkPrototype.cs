using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPrototype : MonoBehaviour
{
    public float moveSpeed = .2f;
    public Rigidbody2D rb;
    Vector2 movement;
    bool RightLeg = true;
    bool LeftLeg = true;
    public bool canMove = true;
    public bool canMoveRight = true;
    public bool canMoveLeft = true;
    public bool canMoveUp = true;
    public bool canMoveDown = true;

    public float walkTime = .5f;
    public float countTime = 0;


    // Update is called once per frame
    void Update()
    {
        countTime = countTime + Time.deltaTime;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0) == true && RightLeg == true)
        {
            RightLeg = false;
            LeftLeg = true;
            countTime = CheckSpeed(countTime);
            if(movement.x == 1 && canMoveRight == true) //going right
            {
                GotoNumberX(rb.position + movement * moveSpeed, canMove);
            }
            if (movement.x == -1 && canMoveLeft == true) //going left
            {
                GotoNumberX(rb.position + movement * moveSpeed, canMove);
            }
            if (movement.y == 1 && canMoveUp == true) //going up
            {
                GotoNumberY(rb.position + movement * moveSpeed, canMove);
            }
            if (movement.y == -1 && canMoveDown == true) //going down
            {
                GotoNumberY(rb.position + movement * moveSpeed, canMove);
            }
           // GotoNumber(movement, rb.position + movement * moveSpeed); // I took away fixedDeltaTime but the move speed needs to go down to .2
        }
        if (Input.GetMouseButtonDown(1) == true && LeftLeg == true)
        {
            RightLeg = true;
            LeftLeg = false;
            countTime = CheckSpeed(countTime);
            if (movement.x == 1 && canMoveRight == true) //going right
            {
                GotoNumberX(rb.position + movement * moveSpeed, canMove);
            }
            if (movement.x == -1 && canMoveLeft == true) //going left
            {
                GotoNumberX(rb.position + movement * moveSpeed, canMove);
            }
            if (movement.y == 1 && canMoveUp == true) //going up
            {
                GotoNumberY(rb.position + movement * moveSpeed, canMove);
            }
            if (movement.y == -1 && canMoveDown == true) //going down
            {
                GotoNumberY(rb.position + movement * moveSpeed, canMove);
            }
            //GotoNumber(movement, rb.position + movement * moveSpeed); // I took away fixedDeltaTime but the moveSpeed needs to go down to .2
        }
    }

    /* public void GotoNumber( Vector2 minValue, Vector2 maxValue) // min is current value and max is the value we want to move to
     {
         if (minValue.x > maxValue.x || minValue.x < maxValue.x)
         {
             if(canMove)
             {
                 if (minValue.x > maxValue.x && canMoveLeft == true)
                 {
                     LeanTween.moveX(this.gameObject, maxValue.x, walkTime).setEaseOutQuad();
                 }
                 if (minValue.x < maxValue.x && canMoveRight == true)
                 {
                     LeanTween.moveX(this.gameObject, maxValue.x, walkTime).setEaseOutQuad();
                 }
             }
         }
         if (minValue.y > maxValue.y || minValue.y < maxValue.y)
         {
             if (canMove)
             {
                 if (minValue.y > maxValue.y && canMoveUp == true) //up
                 {
                     LeanTween.moveY(this.gameObject, maxValue.y, walkTime).setEaseOutQuad();
                 }
                 if (minValue.y < maxValue.y && canMoveDown == true) //down
                 {
                     LeanTween.moveY(this.gameObject, maxValue.y, walkTime).setEaseOutQuad();
                 }
             }
         }

     }*/
    public void GotoNumberX( Vector2 maxValue, bool canMove) // min is current value and max is the value we want to move to
    {
        if(canMove)
        { 
            LeanTween.moveX(this.gameObject, maxValue.x, walkTime).setEaseOutQuad();
        }
    }

    public void GotoNumberY( Vector2 maxValue, bool canMove) // min is current value and max is the value we want to move to
    {
        if (canMove)
        {
            LeanTween.moveY(this.gameObject, maxValue.y, walkTime).setEaseOutQuad();
        }
    }
    public float CheckSpeed(float countTime)
    {
        if (countTime < 0.4f) // the player is clicking fast
        {
            walkTime = .2f; // walkTime is the amount of time it takes to move the character.
        }
        else // the player is clicking slow
        {
            walkTime = .5f;
        }
        countTime = 0;
        return countTime;
    }
   
}

