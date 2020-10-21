using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectedPatrolPoint : patrolPoint
{
    [SerializeField]
    protected float connectivityRadius = 10f;
    [SerializeField]
    List<connectedPatrolPoint> connections;

    public void Start()
    {
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        connections = new List<connectedPatrolPoint>();
        for(int i = 0; i < allWaypoints.Length; i++)
        {
            connectedPatrolPoint nextPatrolPoint = allWaypoints[i].GetComponent<connectedPatrolPoint>();
            if(nextPatrolPoint != null)
            {
                if(Vector3.Distance(gameObject.transform.position, nextPatrolPoint.transform.position) <= connectivityRadius && nextPatrolPoint != this)
                {
                    connections.Add(nextPatrolPoint);
                }
            }
        }
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, connectivityRadius);
    }

    public connectedPatrolPoint nextWaypoint(connectedPatrolPoint prevPoint)
    {
        if(connections.Count <= 0)
        {
            Debug.LogError("Not enough connections for a patrol. Triggered by " + gameObject.name);
            return null;
        }
        else if(connections.Count == 1 && connections.Contains(prevPoint))
        {
            return prevPoint;
        }
        else
        {
            connectedPatrolPoint nextWaypoint;
            int index = 0;

            do
            {
                index = Random.Range(0, connections.Count);
                nextWaypoint = connections[index];
            } while (nextWaypoint == prevPoint);

            return nextWaypoint;
        }
    }
}
