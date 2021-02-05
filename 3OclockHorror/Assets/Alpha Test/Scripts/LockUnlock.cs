using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockUnlock : MonoBehaviour
{
    public bool isLocked; // variable that determines whether the door is locked our not
    public bool hasKey; // variable that determines if you need key for this door
    public bool haveKey; // variable that determines if the player has the key

    public GameObject player; //the player game object
    public Text textBox;

    float dist;
    float timer = 5f;
    float ov;
    // Start is called before the first frame update
    void Start()
    {
        ov = timer;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position); // calculates the distance between the player and this game object
        if (dist <= 0.6f)// checks to see if the player is close enough
        {
            if (isLocked == true)// checks if the door is "locked"
            {
                if (hasKey == true)// checks if the door needs a key
                {
                    if (haveKey == true)
                    {
                        timer = ov;
                        textBox.text = "Press E to unlock the door";

                        if (Input.GetKeyDown("e"))
                        {
                            isLocked = false;
                            hasKey = false;
                            timer = ov;
                            textBox.text = "The door was unlocked";
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown("e"))
                        {
                            timer = ov;
                            textBox.text = "The door is locked, You need a key";
                        }
                    }
                }
                else
                {
                    timer = ov;
                    textBox.text = "Press E to unlock the door";

                    if (Input.GetKeyDown("e"))
                    {
                        isLocked = false;//unlocks the door
                    }
                }
            }
            else
            {
                //Behavior that will allow the player to pass through door

                timer = ov;
                textBox.text = "Press E to lock the door";

                if (Input.GetKeyDown("e"))
                {
                    isLocked = true;// locks the door
                }
            }

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
