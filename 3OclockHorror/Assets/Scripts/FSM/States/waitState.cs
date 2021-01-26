using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "waitState", menuName = "FSM/States/Wait", order = 5)] //make object creatable
public class waitState : abstractFSMState
{
    /**
     * Wait State
     * 
     * The Blind Creep enters the wait state if the player leaves the room after getting agro.
     * If the player re-enters the room, she will lock back on. 
     * Otherwise, she will resume idling upon timer running out.
    **/

    [SerializeField] //Duration trackers so we don't stay idle longer than desired
    float duration = 15f;
    float totalDuration;

    public override void OnEnable() //Ovveride on enable, set state to idle
    {
        base.OnEnable();
        StateType = FSMStateType.WAIT;
    }
    public override bool enterState() //Enter state, once entered set duration to 0
    {
        enteredState = base.enterState();
        if (enteredState)
        {
            totalDuration = 0f;
        }
        executor.UpdateAnimation(Vector2.zero);
        return enteredState;
    }

    public override void updateState() //Update state, check if we have been going too long at this point?
    {
        if (enteredState)
        {
            totalDuration += Time.deltaTime; //Check if the BC has waited long enough for the player
            if(totalDuration >= duration)
            {
                fsm.enterState(FSMStateType.IDLE);
            }

            if(executor.myRoom == player.myRoom)
            {
                fsm.enterState(FSMStateType.CHASE);
            }
        }
    }

    public override bool exitState() //Exit the state
    {
        base.exitState();
        return true;
    }
}
