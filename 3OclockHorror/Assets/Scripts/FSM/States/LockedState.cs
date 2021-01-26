using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LockedState", menuName = "FSM/States/Locked", order = 6)] //Allow creation in project area
public class LockedState : abstractFSMState
{
    /**
     * Locked State
     * 
     * This state is where the blind creep goes after catching the player. This state is only used for that.
     * It locks the BC down, preventing her from doing anything other than cooking animation.
     * Once the timer runs out, she will exit the state into idle.
    **/
    [SerializeField] //Duration trackers so we don't stay idle longer than desired
    float duration = 15f;
    float totalDuration;

    public override void OnEnable()
    {
        base.OnEnable();
        StateType = FSMStateType.LOCKED;
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
    public override void updateState()
    {
        if (enteredState)
        {
            totalDuration += Time.deltaTime;
            if(totalDuration > duration)
            {
                fsm.enterState(FSMStateType.IDLE);
            }
        }
    }
}
