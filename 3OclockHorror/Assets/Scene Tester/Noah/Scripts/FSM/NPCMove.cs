using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    List<GameObject> waypoints = new List<GameObject>();

    NavMeshAgent navMeshAgent;
    int prevIndex;
    Transform destination;



    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if(navMeshAgent == null)
        {
            Debug.LogError("No detected Nav Agent on " + gameObject.name);
        }
        else
        {
            SetDestination();
        }

    }

    public void Update()
    {
        float dist = Vector3.Distance(this.transform.position, destination.position);
        if(dist <= 1f)
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        int index;
        do
        {
            index = (int)Random.Range(0, waypoints.Count);
        } while (index == prevIndex);

        destination = waypoints[index].transform;
        Vector3 targetVector = waypoints[index].transform.position;
        prevIndex = index;
        navMeshAgent.SetDestination(targetVector);

    }
}
