using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class simplePatrol : MonoBehaviour
{
    [SerializeField]
    bool patrolWaiting;
    [SerializeField]
    float totalWaitTime = 3f;
    [SerializeField]
    float switchProb = 0.2f;

    NavMeshAgent myAgent;
    connectedPatrolPoint prevPoint;
    connectedPatrolPoint curPoint;
    bool traveling;
    bool waiting;
    float waitTimer;
    int pointsVisited = 0;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = this.GetComponent<NavMeshAgent>();
        if(myAgent == null)
        {
            Debug.LogError("No agent detected on " + gameObject.name);
        }
        else
        {
            if(curPoint == null)
            {
                GameObject[] allPoints = GameObject.FindGameObjectsWithTag("Waypoint");
                if(allPoints.Length == 0)
                {
                    Debug.LogError("No points found.");
                }
                else
                {
                    while(curPoint == null)
                    {
                        int rand = Random.Range(0, allPoints.Length);
                        connectedPatrolPoint startingPoint = allPoints[rand].GetComponent<connectedPatrolPoint>();
                        if(startingPoint != null)
                        {
                            curPoint = startingPoint;
                        }
                    }
                }
            }
            setDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(traveling && myAgent.remainingDistance <= 1f)
        {
            traveling = false;
            pointsVisited++;

            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                setDestination();
            }
        }
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer >= totalWaitTime)
            {
                waiting = false;
                setDestination();
            }
        }
    }

    //Set a destination based on the current patrol index within the patrol points array.
    private void setDestination()
    {
        if(pointsVisited > 0)
        {
            connectedPatrolPoint nextPoint = curPoint.nextWaypoint(prevPoint);
            prevPoint = curPoint;
            curPoint = nextPoint;
        }
        Vector3 targ = curPoint.transform.position;
        myAgent.SetDestination(targ);
        traveling = true;
    }
}
