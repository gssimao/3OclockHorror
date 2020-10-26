using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="IdleState", menuName = "FSM/States/Idle", order = 1)] //make object creatable
public class idleState : abstractFSMState
{
    [SerializeField] //Duration trackers so we don't stay idle longer than desired
    float duration = 3f;
    float totalDuration;
    List<room> Rooms;
    int prow;
    int pcol;

    public override void OnEnable() //Ovveride on enable, set state to idle
    {
        base.OnEnable();
        StateType = FSMStateType.TRANSFER;
    }
    public override bool enterState() //Enter state, once entered set duration to 0
    {
        enteredState = base.enterState();
        if (enteredState)
        {
            totalDuration = 0f;
        }

        updateRooms();

        return enteredState;
    }

    public override void updateState() //Update state, check if we have been going too long at this point?
    {
        if (enteredState)
        {
            //select a new room from the updated states
            if(Rooms != null)
            {
                int rand = Random.Range(0, Rooms.Count - 1);
                room nextRoom = Rooms[rand];
                while(nextRoom == executor.myRoom)
                {
                    rand = Random.Range(0, Rooms.Count - 1);
                    nextRoom = Rooms[rand];
                }

                executor.gameObject.transform.position = nextRoom.getEntrancePoint().transform.position;
                executor.myRoom = nextRoom;
                executor.curPoint = nextRoom.getEntrancePoint();
                executor.patrolTime = 0f;

                fsm.enterState(FSMStateType.IDLE);
            }
        }
    }

    public override bool exitState() //Exit the state
    {
        base.exitState();
        return true;
    }

    public void updateRooms()
    {
        Rooms.Clear();
        for (int i = 0; i < executor.rooms.rows.Length; i++)
        {
            for (int j = 0; j < executor.rooms.rows[i].row.Length; j++)
            {
                if (executor.rooms.rows[i].row[j] == player.myRoom)
                {
                    pcol = i;
                    prow = j;
                }
            }
        }
        if (executor.rooms.rows[pcol--].row[prow] != null)
        {
            Rooms.Add(executor.rooms.rows[pcol--].row[prow]);
        }
        if (executor.rooms.rows[pcol++].row[prow] != null)
        {
            Rooms.Add(executor.rooms.rows[pcol++].row[prow]);
        }
        if (executor.rooms.rows[pcol].row[prow--] != null)
        {
            Rooms.Add(executor.rooms.rows[pcol].row[prow--]);
        }
        if (executor.rooms.rows[pcol].row[prow++] != null)
        {
            Rooms.Add(executor.rooms.rows[pcol].row[prow++]);
        }
    }
}
