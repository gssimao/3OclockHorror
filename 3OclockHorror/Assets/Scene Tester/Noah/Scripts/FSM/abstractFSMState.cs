using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ExecutionState
{
    NONE, 
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public abstract class abstractFSMState : ScriptableObject
{
    protected NavMeshAgent myAgent;

    public ExecutionState ExecutionState { get; protected set; }

    public virtual void OnEnable()
    { 
        ExecutionState = ExecutionState.NONE;
    }

    public virtual bool enterState()
    {
        bool success = true;
        ExecutionState = ExecutionState.ACTIVE;
        success = (myAgent != null);
        return success;
    }

    public abstract void updateState();

    public virtual bool exitState()
    {
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }

    public virtual void setNavMeshAgent(NavMeshAgent agent)
    {
        if (agent != null)
        {
            myAgent = agent;
        }
    }
}
