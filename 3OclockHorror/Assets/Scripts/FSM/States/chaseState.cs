using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChaseState", menuName = "FSM/States/Chase", order = 3)] //Allow creation in project area
public class chaseState : abstractFSMState
{
    /**
     * Chase State
     * 
     * This is the state the Blind Creep enters upon catching the player from Idle.
     * The BC will navigate towards the player, attempting to close the distance until either:
     *      * The player leaves the room, triggering a change to idle
     *      * The player is caught, triggering hit and causing the BC to lock
    **/
    [SerializeField]
    float speed;
    float tmr = 0f;
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
            if (speed == 0)
            {
                speed = 5;
                Debug.LogError("Default speed not properly set");
            }
        }
        executor.setDestination(player.gameObject);
        return enteredState;
    }

    public override void updateState() //Check if we should still be chasing player. If not, stop. If we should, update player position and continue chase.
    {
        if (enteredState)
        {
            //Update player posiiton
            //executor.setDestination(player.gameObject);
            bool cnt = executor.move(speed); //determines if the NPC has reached the intended target

            //Determine if player is within range of an attack or has left room, either will trigger state change
            if (!cnt || executor.myRoom != player.myRoom)
            {
                if (!cnt && executor.myRoom == player.myRoom) //Check if its just cnt that has decided it's done, in which case hit that player
                {
                    executor.hit(player.gameObject);
                    fsm.enterState(FSMStateType.LOCKED);
                }
                else if (executor.myRoom != player.myRoom && cnt) //This will only fire if the player has left the room whilst being chased.
                {
                    fsm.enterState(FSMStateType.WAIT);
                }
                else
                {
                    fsm.enterState(FSMStateType.IDLE);
                }
            }
        }
    }
}
