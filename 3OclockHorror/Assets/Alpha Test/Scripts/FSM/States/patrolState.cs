using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatrolState", menuName = "FSM/States/Patrol", order = 2)] //Allow creation in project area
public class patrolState : abstractFSMState
{
    public override void OnEnable() //overide onEnable to set state type
    {
        base.OnEnable();
        StateType = FSMStateType.PATROL;
    }
    public override bool enterState() //Enter Patrol State - make sure everything is in place, then set destination
    {
        enteredState = false;
        if (base.enterState())
        {
            if(executor != null)
            {
                executor.setDestination();
                enteredState = true;
            }
        }
        return enteredState;
    }

    public override void updateState() //Check if we are near destination, if so then exit sate
    {
        if (enteredState)
        {
            bool cnt = executor.move();
            if (!cnt)
            {
                fsm.enterState(FSMStateType.IDLE);
            }
        }
    }
}
