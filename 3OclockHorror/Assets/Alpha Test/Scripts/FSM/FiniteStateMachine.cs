using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField]
    abstractFSMState startingState; //Default starting state - default idle, set in editor
    abstractFSMState currentState; //Current state being executed
    abstractFSMState prevState; //previous state that was executed

    [SerializeField]
    List<abstractFSMState> validStates; //List of valid states, set in editor
    Dictionary<FSMStateType, abstractFSMState> fsmStates; //Container to correlate enum states to an actual state
    public PlayerMovement player;

    public void Awake()
    {
        currentState = null; //Set state to null

        fsmStates = new Dictionary<FSMStateType, abstractFSMState>(); //Initialize state container
        NavMeshAgent agent = this.GetComponent<NavMeshAgent>(); //Set navmesh agent
        NPC npc = this.GetComponent<NPC>(); //Set NPC executor
        
        foreach(abstractFSMState state in validStates) //Grab each state in validStates, add it to valid states container and set control variables
        {
            state.setExecutingFSM(this);
            state.setExecutingAgent(npc);
            state.setNavMeshAgent(agent);
            state.setPlayer(player);
            fsmStates.Add(state.StateType, state);
        }
    }

    public void Start() //Enter a state
    {
        enterState(startingState);
    }

    public void Update() //Update a state
    {
        if (currentState != null)
        {
            currentState.updateState();
            Debug.Log("State: " + currentState.StateType.ToString());
        }
    }

    public FSMStateType GetState()
    {
        return currentState.StateType;
    }

    #region STATE MANAGEMENT

    public void enterState(abstractFSMState nextState) //Enter the next desired state
    {
        if(nextState == null)
        {
            return;
        }
        else
        {
            prevState = currentState;
            if(currentState != null)
            {
                currentState.exitState();
            }
            currentState = nextState;
            currentState.enterState();
        }
    }

    public void enterState(FSMStateType stateType) //Checks that listed state is valid, then calls previous funtion according to entry
    {
        if (fsmStates.ContainsKey(stateType))
        {
            abstractFSMState nextState = fsmStates[stateType];
            enterState(nextState);
        }
    }

    #endregion //manage state
}

