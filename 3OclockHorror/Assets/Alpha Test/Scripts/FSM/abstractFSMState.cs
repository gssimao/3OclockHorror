using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ExecutionState //Enum for all of the possible state points
{
    NONE, 
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public enum FSMStateType //Types of valid states, also must add state to valid states array on FiniteStateMachine class
{
    IDLE,
    PATROL,
    CHASE,
};

public abstract class abstractFSMState : ScriptableObject
{
    protected NavMeshAgent myAgent; //Nav mesh agent
    protected NPC executor; //NPC controlling this state instance
    protected FiniteStateMachine fsm; //The fsm controlling this state
    protected PlayerMovement player;

    public bool enteredState { get; protected set; } //Entered state?
    public ExecutionState ExecutionState { get; protected set; } //Current execution state
    public FSMStateType StateType { get; protected set; } //Current state

    public virtual void OnEnable()
    { 
        ExecutionState = ExecutionState.NONE; //Set state point to none
    }

    public virtual bool enterState() //Basic version of entering a state
    {
        bool success = true;
        ExecutionState = ExecutionState.ACTIVE;
        success = (myAgent != null);
        success = (executor != null);
        return success;
    }

    public abstract void updateState(); //Update state

    public virtual bool exitState() //Exit a state
    {
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }

    #region Setters
    public virtual void setNavMeshAgent(NavMeshAgent agent) //Set the nav mesh
    {
        if (agent != null)
        {
            myAgent = agent;
        }
    }
    public virtual void setExecutingAgent(NPC npc) //Set NPC
    {
        if(npc != null)
        {
            executor = npc;
        }
    }
    public virtual void setExecutingFSM(FiniteStateMachine exFSM) //Set FSM
    {
        fsm = exFSM;
    }
    public virtual void setPlayer(PlayerMovement p) //Set the player movement conmponent
    {
        player = p;
    }
    #endregion //Things to set various control variables
}
