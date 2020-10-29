using System.Collections;
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
    public Camera Camera;
    public Vector2 movement;
    public AudioManager manager;
    public bool isPlaying = false; //for audio

    public CandleScript[] Candles;
    public CandleScript CandleInRange;
    public GameObject transferCanvas;
    float cndlTmr;
    float duration = 1f;

    void Start()
    {
        invUI.SetActive(false);
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        if (!invUI.activeSelf && !transferCanvas.activeSelf)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }

        //Check the states for the walk animation.
        #region ChecKWalkStates 
        if (movement.x < 0)
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
        #endregion

        if (movement.x != 0 || movement.y != 0)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        if (walking == true && isPlaying == false && manager != null)
        {
            manager.Play("Player Footsteps");
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Camera.transform.position = myRoom.getCameraPoint().transform.position;

        if(cndlTmr >= duration)
        {
            CheckCandle();
            cndlTmr = 0f;
        }
        else
        {
            cndlTmr += Time.deltaTime;
        }
    }

    void CheckCandle()
    {
        Candles = myRoom.getRoomObject().GetComponentsInChildren<CandleScript>();

        foreach(CandleScript candle in Candles)
        {
            float dist = Vector2.Distance(gameObject.transform.position, candle.transform.position);
            if(dist < 1)
            {
                CandleInRange = candle;
                return;
            }
        }
    }
}
