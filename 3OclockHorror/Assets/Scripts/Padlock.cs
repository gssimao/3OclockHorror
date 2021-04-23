using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padlock : MonoBehaviour
{
    [SerializeField]
    public bool solved;
    //Rotating elements of the lock
    [SerializeField]
    LockControl lock1;
    [SerializeField]
    LockControl lock2;
    [SerializeField]
    LockControl lock3;
    [SerializeField]
    LockControl lock4;

    //List of doors to be unlocked when called
    [SerializeField]
    List<roomCntrl> doors;

    //List of photos to check lock against
    public Item Photo1;
    public Item Photo2;
    public Item Photo3;
    public Item Photo4;

    [SerializeField]
    GameObject isSolved;
    [SerializeField]
    Animator lockAnim;

    AudioManager manager;

    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnswer();

        /*if(lockAnim.GetCurrentAnimatorStateInfo(0).IsName("PadlockOpen") && solved)
        {
            lockAnim.gameObject.SetActive(false);
        }*/
    }

    public void CheckAnswer()
    {
        //Before checking, see if the puzzle is solved already
        if (!solved && 
        lock1.numeral == Photo1.numeral && lock2.numeral == Photo2.numeral &&
        lock3.numeral == Photo3.numeral && lock4.numeral == Photo4.numeral) 
        {
            foreach (roomCntrl door in doors) //If they all match, unlock all respective doors assigned to this function
            {
                door.locked = false;
            }
            solved = true;
            lockAnim.SetTrigger("unlock");
            manager.Play("Success", false);
        }
    }
}

