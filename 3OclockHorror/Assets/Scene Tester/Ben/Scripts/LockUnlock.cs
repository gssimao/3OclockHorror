using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockUnlock : MonoBehaviour
{
    public bool isLocked; // variable that determines whether the door is locked our not
    public bool hasKey; // variable that determines if you need key for this door
    public bool haveKey; // variable that determines if the player has the key

    public GameObject player; //the player game object
    public GameObject axis;

    float dist;
    float angle = 0;
    Vector3 OP; //original position of the door;
    // Start is called before the first frame update
    void Start()
    {
        OP = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(OP, player.transform.position); // calculates the distance between the player and the this game object
        if (dist <= 2f)// checks to see if the player is close enough
        {
            if (isLocked == true)// checks if the door is "locked"
            {
                if (hasKey == true)// checks if the door needs a key
                {
                    if (haveKey == true)
                    {
                        //future
                    }
                }
                else
                {
                    if (Input.GetKeyDown("e"))
                    {
                        isLocked = false;// allows you to unlock the door
                    }
                }
            }
            else
            {
                if (angle < 90)
                {
                    gameObject.transform.RotateAround(axis.transform.position, Vector3.forward, angle);// rotates the object around an axis

                    angle = angle + 10 * Time.deltaTime;// the angle that the door turns to
                }

                if (Input.GetKeyDown("e"))
                {
                    isLocked = true;// locks the door
                }
            }
        }
        else
        {
            gameObject.transform.position = new Vector3(OP.x, OP.y, OP.z);// sets the door back to it's original position when the player is far enough away
            angle = 0;
        }
    }
}
