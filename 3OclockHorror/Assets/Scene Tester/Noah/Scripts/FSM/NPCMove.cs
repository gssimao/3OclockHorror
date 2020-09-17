using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    Transform destination;

    NavMeshAgent navMeshAgent;



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
        if (destination != null)
        {
            Vector3 targetVector = destination.position;
            navMeshAgent.SetDestination(targetVector);
        }
        else
        {
            Debug.LogError("No destination set for " + this.gameObject.name);
        }
    }
}
