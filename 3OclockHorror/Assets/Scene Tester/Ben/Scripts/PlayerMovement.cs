using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
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
    float cndlTmr;
    float duration = 1f;

    //For Changing Scenes
    public GameObject Cntnr;
    public InventoryManager charPanel;
    public GameObject ToolTip;
    public GameObject wbInventory;

    //A list of all canvases that should block player movement
    public List<GameObject> Canvases; //Canvases that won't be deleted between scenes
    public List<GameObject> tempCanvases; //Canvases that will be deleted
    bool canMove;

    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove = true;

        anim.SetBool("walkingLeft", false);
        anim.SetBool("walkingRight", false);
        anim.SetBool("walkingForwards", false);
        anim.SetBool("walkingBackwards", false);

        if(Canvases != null)
        {
            foreach(GameObject canv in Canvases)
            {
                if (canv.activeSelf)
                {
                    canMove = false;
                }
            }
        }
        if (tempCanvases != null)
        {
            foreach (GameObject canv in tempCanvases)
            {
                if (canv.activeSelf)
                {
                    canMove = false;
                }
            }
        }

        // Input

        if (canMove)
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

        if (movement.x != 0 && movement.y != 0)
        {
            if (movement.x < 0)
            {
                anim.SetBool("walkingLeft", true);
            }

            if (movement.x > 0)
            {
                anim.SetBool("walkingRight", true);
            }
        }
        else
        {
            if (movement.x != 0)
            {
                if (movement.x < 0)
                {
                    anim.SetBool("walkingLeft", true);
                }

                if (movement.x > 0)
                {
                    anim.SetBool("walkingRight", true);
                }
            }
            
            if(movement.y != 0)
            {
                if (movement.y < 0)
                {
                    anim.SetBool("walkingForwards", true);
                }

                if (movement.y > 0)
                {
                    anim.SetBool("walkingBackwards", true);
                }
            }
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
        if (Camera != null)
        {
            Camera.transform.position = myRoom.getCameraPoint().transform.position;
        }

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
        if (myRoom != null)
        {
            Candles = myRoom.getRoomObject().GetComponentsInChildren<CandleScript>();

            foreach (CandleScript candle in Candles)
            {
                float dist = Vector2.Distance(gameObject.transform.position, candle.transform.position);
                if (dist < 1)
                {
                    CandleInRange = candle;
                    return;
                }
            }
        }
    }

    public GameObject getJournal()
    {
        return Canvases[2];
    }
}
