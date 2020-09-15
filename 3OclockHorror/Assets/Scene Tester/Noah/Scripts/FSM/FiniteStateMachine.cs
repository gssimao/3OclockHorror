using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField]
    abstractFSMState startingState;
    abstractFSMState currentState;
    abstractFSMState prevState;

    public void Awake()
    {
        currentState = null;
    }

    public void Start()
    {
        enterState(startingState);
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.updateState();
        }
    }

    #region STATE MANAGEMENT

    public void enterState(abstractFSMState nextState)
    {
        if(nextState == null)
        {
            return;
        }
        else
        {
            prevState = currentState;
            currentState = nextState;
            currentState.enterState();
        }
    }

    #endregion
}

