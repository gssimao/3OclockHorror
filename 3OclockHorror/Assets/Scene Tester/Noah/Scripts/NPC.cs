using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
public class NPC : MonoBehaviour
{
    //Public (editor assigned) Variables
    public GameObject player; //The player target for the Blind Creep to head towards / check against
    //Watcher reference as well perhaps?

    //Internals
    NavMeshAgent meshAgent; //Navigation Agent
    FiniteStateMachine fsm; //Finite state machine reference

    public connectedPatrolPoint prevPoint {get; protected set;} //Previous nav point
    public connectedPatrolPoint curPoint { get; protected set; } //Current nav point
    int pointsVisited = 0;

    public room myRoom;

    // Start is called before the first frame update
    void Awake()
    {
        fsm = this.GetComponent<FiniteStateMachine>(); //get the mesh anf fsm components
        meshAgent = this.GetComponent<NavMeshAgent>();
        if (meshAgent == null || fsm == null) //Double check for nullness 
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

    //Set a destination based on the current patrol index within the patrol points array.
    public void setDestination()
    {
        if (pointsVisited > 0) //if the points visited are greater than one
        {
            connectedPatrolPoint nextPoint = curPoint.nextWaypoint(prevPoint); //Get an adjacent waypoint to be the next point
            prevPoint = curPoint; //Set the prev point
            curPoint = nextPoint; //Set the current point
        }
        Vector3 targ = curPoint.transform.position; //Start moving towards that point
        meshAgent.SetDestination(targ);
    }

    public void setDestination(GameObject targ)
    {
        Vector3 target = targ.transform.position;
        meshAgent.SetDestination(target);
    }
}
