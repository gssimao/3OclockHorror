using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TransferState", menuName = "FSM/States/Transfer", order = 4)] //make object creatable
public class transferState : abstractFSMState
{
    [SerializeField] //Duration trackers so we don't stay idle longer than desired
    float duration = 5f;
    float totalDuration;

    public override void OnEnable() //Ovveride on enable, set state to idle
    {
        base.OnEnable();
        StateType = FSMStateType.IDLE;
    }
    public override bool enterState() //Enter state, once entered set duration to 0
    {
        enteredState = base.enterState();
        if (enteredState)
        {
            totalDuration = 0f;
        }
        return enteredState;
    }

    public override void updateState() //Update state, check if we have been going too long at this point?
    {
        if (enteredState)
        {
            totalDuration += Time.deltaTime;
            executor.pTime += Time.deltaTime;
            if(executor.pTime >= 30f && executor.myRoom != player.myRoom)
            {
                fsm.enterState(FSMStateType.TRANSFER);
            }
            else if(totalDuration >= duration)
            {
                fsm.enterState(FSMStateType.PATROL);
            }

            if(totalDuration >= 0.5f)
            {
                if(player.movement.x != 0 && player.myRoom == executor.myRoom)
                {
                    executor.patrolTime = 0f;
                    fsm.enterState(FSMStateType.CHASE);
                }
                else if (player.movement.y != 0 && player.myRoom == executor.myRoom)
                {
                    executor.patrolTime = 0f;
                    fsm.enterState(FSMStateType.CHASE);
                }
            }
        }
    }

    public override bool exitState() //Exit the state
    {
        base.exitState();
        return true;
    }
}
