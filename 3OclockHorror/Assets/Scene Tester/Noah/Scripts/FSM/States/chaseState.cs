using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChaseState", menuName = "FSM/States/Chase", order = 3)] //Allow creation in project area
public class chaseState : abstractFSMState
{
    public override void OnEnable() //overide onEnable to set state type
    {
        base.OnEnable();
        StateType = FSMStateType.CHASE;
    }
    public override bool enterState() //Enter Patrol State - make sure everything is in place, then set destination
    {
        enteredState = false;
        if (base.enterState())
        {
            if (executor != null)
            {
                enteredState = true;
            }
        }
        return enteredState;
    }

    public override void updateState() //Check if we should still be chasing player. If not, stop. If we should, update player position and continue chase.
    {
        if (enteredState)
        {
            //Determine if player is within range of an attack or has left room, either will trigger state change
            if (Vector3.Distance(myAgent.transform.position, player.gameObject.transform.position) <= 0.5f || executor.myRoom != player.myRoom)
            {
                fsm.enterState(FSMStateType.IDLE);
            }

            //Update player posiiton
            executor.setDestination(player.gameObject);
        }
    }
}
