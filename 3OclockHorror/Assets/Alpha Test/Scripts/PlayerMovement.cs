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
    public string playerFloor = "FirstFloor";

    //For Changing Scenes
    public GameObject Cntnr;
    public InventoryManager charPanel;
    public GameObject ToolTip;
    public GameObject wbInventory;
    public Transform contSlots;

    //A list of all canvases that should block player movement
    public List<GameObject> Canvases; //Canvases that won't be deleted between scenes
    public List<GameObject> tempCanvases; //Canvases that will be deleted
    bool canMove;

    //bool RightLeg = true;
    //bool LeftLeg = true;

    public float walkTime = .5f;
    public float countTime = 0;
    public bool canMoveRight = true;
    public bool canMoveLeft = true;
    public bool canMoveUp = true;
    public bool canMoveDown = true;
    private UniversalControls uControls;

    public bool leftSide = false;

    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();
    }
    private void OnDisable()
    {
        uControls.Disable();
    }
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        if (manager != null)
        {
            //manager.Play("Heavy Wind");
        }
        Debug.Log("hello");
    }

    // Update is called once per frame
    void Update()
    {
        resetState();
        if (Canvases != null)
        {
            foreach (GameObject canv in Canvases)
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

        //Check if the player can move and is registering input
        if (canMove)
        {
            movement.x = uControls.Player.MovePlayer.ReadValue<Vector2>().x;//Input.GetAxisRaw("Horizontal");
            movement.y = uControls.Player.MovePlayer.ReadValue<Vector2>().y;//Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
        movement.x = uControls.Player.MovePlayer.ReadValue<Vector2>().x;//Input.GetAxisRaw("Horizontal");
        movement.y = uControls.Player.MovePlayer.ReadValue<Vector2>().y; //Input.GetAxisRaw("Vertical");

        #region Depreciated_mouse_control
        /*
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////// testing here
        if (Input.GetMouseButtonDown(0) == true && RightLeg == true && canMove == true)
        {
            RightLeg = false;
            LeftLeg = true;
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
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetMouseButtonDown(1) == true && LeftLeg == true && canMove == true)
        {
            RightLeg = true;
            LeftLeg = false;
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
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        */
        #endregion

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

            if (movement.y != 0)
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

        if (walking == true && isPlaying == false && manager != null && myRoom.getName() != "Outside")
        {
            manager.Play("Player Footsteps", true);
            isPlaying = true;
        }
        else if (walking == true && isPlaying == false && manager != null && myRoom.getName() == "Outside")
        {
            manager.Play("Snow Footsteps", true);
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
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);  // take the comments out to go back to normal
        }
        if (Camera != null)
        {
            Camera.transform.position = myRoom.getCameraPoint().transform.position;
        }
    }

    public GameObject getJournal()
    {
        return Canvases[2];
    }

    public void changeRoom(room room)
    {
        myRoom = room;
    }
    public void resetState()
    {
        canMove = true;

        anim.SetBool("walkingLeft", false);
        anim.SetBool("walkingRight", false);
        anim.SetBool("walkingForwards", false);
        anim.SetBool("walkingBackwards", false);
    }
}

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////// new stuff here, testing
    /*public void GotoNumberX(Vector2 maxValue, bool canMove) // min is current value and max is the value we want to move to
    {
        if (canMove)
        {
            LeanTween.moveX(this.gameObject, maxValue.x, walkTime).setEaseOutQuad();
        }
    }
    public void GotoNumberY(Vector2 maxValue, bool canMove) // min is current value and max is the value we want to move to
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
}*/
