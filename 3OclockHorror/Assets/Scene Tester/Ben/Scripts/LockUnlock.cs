using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockUnlock : MonoBehaviour
{
    public bool isLocked; // variable that determines whether the door is locked our not
    public bool hasKey; // variable that determines if you need key for this door
    public bool haveKey; // variable that determines if the player has the key
    public float time;

    public GameObject player; //the player game object
    public Text textBox;

    float dist;
    float timer = 5f;
    float ov;
    Vector3 OP; //original position of the door;
    // Start is called before the first frame update
    void Start()
    {
        OP = gameObject.transform.position;
        ov = timer;
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
                    else
                    {
                        if (Input.GetKeyDown("e"))
                        {
                            textBox.text = "The door is locked";
                        }
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
                /*if (angle < 90)
                {
                    gameObject.transform.RotateAround(axis.transform.position, Vector3.forward, angle);// rotates the object around an axis

                    angle = angle + 10 * Time.deltaTime;// the angle that the door turns to
                }*/

                if (Input.GetKeyDown("e"))
                {
                    isLocked = true;// locks the door
                }
            }
            
        }
        else
        {
            gameObject.transform.position = new Vector3(OP.x, OP.y, OP.z);// sets the door back to it's original position when the player is far enough away
        }

        if (textBox.text != "")
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            textBox.text = "";
            timer = ov;
        }
    }
}
