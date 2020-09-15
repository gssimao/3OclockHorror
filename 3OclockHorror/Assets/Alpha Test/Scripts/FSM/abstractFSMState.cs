using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExecutionState
{
    NONE, 
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public abstract class abstractFSMState : ScriptableObject
{
    public ExecutionState ExecutionState { get; protected set; }

    public virtual void OnEnable()
    { 
        ExecutionState = ExecutionState.NONE;
    }

    public virtual bool enterState()
    {
        ExecutionState = ExecutionState.ACTIVE;
        return true;
    }

    public abstract void updateState();

    public virtual bool exitState()
    {
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }
}
