using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(FiniteStateMachine), typeof(Seeker), typeof(Rigidbody2D))]
public class NPC : MonoBehaviour
{
    //Public (editor assigned) Variables
    public GameObject player; //The player target for the Blind Creep to head towards / check against
    public Animator anim;
    //Watcher reference as well perhaps?

    //Internals
    FiniteStateMachine fsm; //Finite state machine reference

    public connectedPatrolPoint prevPoint {get; protected set;} //Previous nav point
    public connectedPatrolPoint curPoint { get; protected set; } //Current nav point
    int pointsVisited = 0;

    public room myRoom;

    public float speed = 5f;
    public float nWPD = 0.1f;

    Path path;
    int currWP = 0;
    Seeker seeker;
    Rigidbody2D rb;
    public Vector2 movement;


    // Start is called before the first frame update
    void Awake()
    {
        fsm = this.GetComponent<FiniteStateMachine>(); //get the mesh anf fsm components
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (fsm == null) //Double check for nullness 
        {
            Debug.LogError("Critical component missing on " + gameObject.name);
        }
        else
        {
            if (curPoint == null) //If the current point is null
            {
                GameObject[] allPoints = GameObject.FindGameObjectsWithTag("Waypoint"); //Grab all waypoints
                if (allPoints.Length == 0) //make sure the points are not null
                {
                    Debug.LogError("No points found.");
                }
                else //Else, set a point
                {
                    while (curPoint == null)
                    {
                        int rand = Random.Range(0, allPoints.Length); //Grab a rand index
                        connectedPatrolPoint startingPoint = allPoints[rand].GetComponent<connectedPatrolPoint>(); //get the point
                        if (startingPoint != null) //make sure it's not null
                        {
                            curPoint = startingPoint; //Set the current point, increment the points visited
                            pointsVisited++;
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
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

        // Input
        /*movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/







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

    public bool move()
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
