using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LightState", menuName = "FSM/States/Light", order = 5)] //make object creatable
public class lightState : abstractFSMState
{
    [SerializeField] //Duration trackers so we don't stay idle longer than desired
    float duration = 3f;
    float currDuration;
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
            currDuration += Time.deltaTime;
            if(currDuration > duration)
            {
                if(executor.myRoom != player.myRoom)
                {
                    fsm.enterState(FSMStateType.IDLE);
                }
                else
                {
                    //Logic to move closer to candle then further away 
                    //Will have to probably do sin/cos math to find how to move towards candle, track candle, etc
                    //If player runs out, BC should re-enter chase (if not walking)
                }

                currDuration = 0f;
            }
            if(totalDuration >= 30f)
            {
                fsm.enterState(FSMStateType.IDLE);
            }
        }
    }

    public override bool exitState() //Exit the state
    {
        base.exitState();
        return true;
    }
}
