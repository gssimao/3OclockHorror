using System.Collections;
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
    public Animator anim;
    //Watcher reference as well perhaps?

    //Internals
    FiniteStateMachine fsm; //Finite state machine reference

    public connectedPatrolPoint prevPoint {get; protected set;} //Previous nav point
    public connectedPatrolPoint curPoint;
    int pointsVisited = 0;

    public room myRoom;
    public float nWPD = 0.1f;
    public float patrolTime = 0f;

    Path path;
    int currWP = 0;
    Seeker seeker;
    public Rigidbody2D rb;
    public float pTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        fsm = this.GetComponent<FiniteStateMachine>(); //get the mesh anf fsm components
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (fsm == null) //Double check for nullness 
        {
            Debug.LogError("Critical component missing on " + gameObject.name + ": fsm component");
        }
        else
        {
            if (curPoint == null) //If the current point is null
            {
                Debug.LogError("Current Point must be set in editor.");
            }
        }
    }

    void Update()
    {
        FileIO.WriteStringToFile("debug.txt", this.GetType().Name + " " + this.gameObject.name + " starting at " + Time.time.ToString(), true);

        if (rb.velocity.x > 0)
        {
            anim.SetBool("walkingright", true);
        }
        else
        {
            anim.SetBool("walkingright", false);
        }
        if (rb.velocity.x < 0)
        {
            anim.SetBool("walkingleft", true);
        }
        else
        {
            anim.SetBool("walkingleft", false);
        }

        FileIO.WriteStringToFile("debug.txt", this.GetType().Name + " " + this.gameObject.name + " ending at " + Time.time.ToString(), true);
    }

    //Set a destination based on the current patrol index within the patrol points array.
    public void setDestination()
    {
        if (pointsVisited > 0) //if the points visited are greater than one
        {
            connectedPatrolPoint nextPoint = curPoint.nextWaypoint(curPoint); //Get an adjacent waypoint to be the next point
            prevPoint = curPoint; //Set the prev point
            curPoint = nextPoint; //Set the current point
        }
        UpdatePath(curPoint.gameObject.transform);

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
            return false;
        }
        else
        {
            Vector2 dir = ((Vector2)path.vectorPath[currWP] - rb.position).normalized;
            Vector2 force = dir * speed * Time.deltaTime;
            rb.AddForce(force);

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

        if(clock != null && targSAN != null)
        {
            targSAN.ChangeSanity(-10);
            clock.adjustEndTime(-60);
        }
    }

}
