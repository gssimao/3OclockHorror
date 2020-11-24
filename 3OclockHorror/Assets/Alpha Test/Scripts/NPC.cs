﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(FiniteStateMachine), typeof(Seeker), typeof(Rigidbody2D))]
public class NPC : MonoBehaviour
{
    [SerializeField]
    public ArrayLayout rooms;

    //Public (editor assigned) Variables
    public GameObject player; //The player target for the Blind Creep to head towards / check against
    PlayerMovement pmove;
    public Animator anim;
    //Watcher reference as well perhaps?

    //Internals
    FiniteStateMachine fsm; //Finite state machine reference

    public connectedPatrolPoint prevPoint {get; protected set;} //Previous nav point
    public connectedPatrolPoint curPoint;
    int pointsVisited = 0;

    public room myRoom;
    public float nWPD = 0.25f;
    public float patrolTime = 0f; //Time that npc has been idle

    Path path;
    int currWP = 0;
    Seeker seeker;
    public Rigidbody2D rb;
    public float pTime = 0f; //Time since last transfer

    AudioManager manager;
    public bool isWalking = false;
    public bool isRunning = false;
    public bool isPlaying = false;

    int hitTmr;

    // Start is called before the first frame update
    void Awake()
    {
        fsm = this.GetComponent<FiniteStateMachine>(); //get the mesh anf fsm components
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<AudioManager>();

        if (fsm == null) //Double check for nullness 
        {
            Debug.LogError("Critical component missing on " + gameObject.name + ": fsm component");
        }
        else
        {
            if (curPoint == null) //If the current point is null
            {
                Debug.LogWarning("Current Point must be set in editor.");
            }
        }
        pmove = player.GetComponent<PlayerMovement>();
        hitTmr = 0;
    }

    void Update()
    {
        
        if (hitTmr > 0)
        {
            hitTmr--;
        }
    }

    //Set a destination based on the current patrol index within the patrol points array.
    public void setDestination()
    {
        if (pointsVisited > 0) //if the points visited are greater than one
        {
            connectedPatrolPoint nextPoint = curPoint.nextWaypoint(prevPoint); //Get an adjacent waypoint to be the next point
            prevPoint = curPoint; //Set the prev point
            curPoint = nextPoint; //Set the current point
        }
        UpdatePath(curPoint.gameObject.transform);
        pointsVisited++;
    }
    public void setDestination(GameObject targ)
    {
        UpdatePath(targ.transform);
    }

    void UpdatePath(Transform targ)
    {
        seeker.StartPath(gameObject.transform.position, targ.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currWP = 0;
        }
        else
        {
            Debug.LogError("No path given.");
        }
    }

    public bool move(float speed)
    {
        if (path == null)
        {
            return false;
        }

        if (currWP >= path.vectorPath.Count)
        {
            UpdateAnimation(Vector2.zero);
            return false;
        }
        else
        {
            Vector2 dir = ((Vector2)path.vectorPath[currWP] - rb.position).normalized;
            Vector2 force = dir * speed * Time.deltaTime;
            this.transform.Translate(force);
            UpdateAnimation(dir);

            float dist = Vector2.Distance(rb.position, path.vectorPath[currWP]);
            if (dist < nWPD)
            {
                currWP++;
            }

            return true;
        }

    }

    public void hit(GameObject target)
    {
        SanityManager targSAN = target.GetComponent<SanityManager>();
        clockCntrl clock = target.GetComponent<clockCntrl>();

        float dist = Vector2.Distance(target.transform.position, this.gameObject.transform.position);

        if(clock != null && targSAN != null && dist <= 0.5 && hitTmr == 0)
        {
            targSAN.ChangeSanity(-10);
            clock.adjustEndTime(-60);
            hitTmr = 200;

            //Script to fade to black and transfer rooms to cover time change
        }
    }

    public void UpdateAnimation(Vector2 dir)
    {
        isWalking = false;
        isRunning = false;

        if (fsm.GetState() != FSMStateType.IDLE)
        {
            if (fsm.GetState() == FSMStateType.PATROL)
            {
                if (dir.x > 0.01)
                {
                    anim.SetBool("walkingright", true);
                    isWalking = true;
                }
                else
                {
                    anim.SetBool("walkingright", false);
                }

                if (dir.x < -0.01)
                {
                    anim.SetBool("walkingleft", true);
                    isWalking = true;
                }
                else
                {
                    anim.SetBool("walkingleft", false);
                }
            }
            else if (fsm.GetState() == FSMStateType.CHASE)
            {
                if (dir.x > 0.01)
                {
                    anim.SetBool("runright", true);
                    isRunning = true;
                }
                else
                {
                    anim.SetBool("runright", false);
                }

                if (dir.x < -0.01)
                {
                    anim.SetBool("runleft", true);
                    isRunning = true;
                }
                else
                {
                    anim.SetBool("runleft", false);
                }
            }
        }
        else if(fsm.GetState() == FSMStateType.IDLE)
        {
            anim.SetBool("walkingright", false);
            anim.SetBool("walkingleft", false);
            anim.SetBool("runright", false);
            anim.SetBool("runleft", false);
            isWalking = false;
            isRunning = false;
        }
        else
        {
            Debug.Log("No matching state, can't update");
        }

        if (isWalking == true && manager != null && isPlaying == false && pmove.myRoom == myRoom)
        {
            manager.Play("Blind Creep Footsteps"); //For now I'm having them be the same sound effect. Will change later.
            isPlaying = true;
        }
        else if (isRunning == true && manager != null && isPlaying == false && pmove.myRoom == myRoom)
        {
            manager.Play("Blind Creep Footsteps");
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
    }

}
