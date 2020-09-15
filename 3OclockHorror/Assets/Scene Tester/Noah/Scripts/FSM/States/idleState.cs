using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="IdleState", menuName = "FSM/States/Idle", order = 1)]
public class idleState : abstractFSMState
{
    public override bool enterState()
    {
        base.enterState();
        Debug.Log("Entered Idle state");
        return true;
    }

    public override void updateState()
    {
        Debug.Log("Updating idle state");
    }

    public override bool exitState()
    {
        base.exitState();
        Debug.Log("Exiting idle state");
        return true;
    }


}
