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
    float ftm;
    bool move;
    int moveStage;

    public override void OnEnable() //Ovveride on enable, set state to idle
    {
        base.OnEnable();
        StateType = FSMStateType.LIGHT;
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
        FileIO.WriteStringToFile("debug.txt", this.GetType().Name + " " + " starting at " + Time.time.ToString(), true);
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
                else if(!move)
                {
                    //Logic to move closer to candle then further away
                    //If player runs out, BC should re-enter chase (if not walking)
                    ftm = Random.Range(5, 15); //Force to move by. Applied to move forwards / backwards towards candle
                    move = true;
                    moveStage = 0;
                    executor.setDestination(player.CandleInRange.gameObject);
                }

                if (move)
                {
                    if (moveStage == 0)
                    {
                        executor.move(ftm);
                        moveStage = 1;
                    }
                    else if (moveStage == 1)
                    {
                        executor.move(-ftm);
                        moveStage = 2;
                    }
                    else if(moveStage == 2)
                    {
                        executor.move(-ftm);
                        moveStage = 3;
                    }
                    else if(moveStage == 3)
                    {
                        executor.move(ftm);
                        move = false;
                    }
                }

                currDuration = 0f;
            }
            if(totalDuration >= 30f)
            {
                fsm.enterState(FSMStateType.IDLE);
            }
        }
        FileIO.WriteStringToFile("debug.txt", this.GetType().Name + " " + " ending at " + Time.time.ToString(), true);
    }

    public override bool exitState() //Exit the state
    {
        base.exitState();
        return true;
    }
}
