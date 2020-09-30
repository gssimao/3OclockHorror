using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Pathfinding;

public class mover : MonoBehaviour
{/*
    //Transform targ;
    public float speed = 1f;
    public float nWPD = 3f;

    Path path;
    int currWP = 0;
    //bool reachedEOP = false;
    Seeker seeker;
    Rigidbody2D rb;

    connectedPatrolPoint curPoint;
    connectedPatrolPoint prevPoint;
    int pointsVisited;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

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

        UpdatePath(curPoint.transform);
    }

    void UpdatePath(Transform targ)
    {
        seeker.StartPath(gameObject.transform.position, targ.position, OnPathComplete);
    }

    void ChooseNextDest()
    {
        if (pointsVisited > 0) //if the points visited are greater than one
        {
            connectedPatrolPoint nextPoint = curPoint.nextWaypoint(prevPoint); //Get an adjacent waypoint to be the next point
            prevPoint = curPoint; //Set the prev point
            curPoint = nextPoint; //Set the current point
        }
        UpdatePath(curPoint.gameObject.transform);
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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currWP >= path.vectorPath.Count)
        {
            ChooseNextDest();
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
        }

    }*/
}
