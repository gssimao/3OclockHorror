using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="transferState", menuName = "FSM/States/Transfer", order = 4)] //make object creatable
public class transferState : abstractFSMState
{
    /**
    * Transfer State
    * 
    * In this state, the Blind Creep will attempt to transfer rooms. 
    * First, she will look at the player's room, finding it in her list if it's there.
    * Then she will form a list of nearby rooms, assuming at least one is adjacent. If so, she will teleport there.
    * If she finds nothing, her timers will reset and she will stay in her current room.
    * In either case, she will resume idling. 
    **/
    List<room> Rooms;
    room ChosenRoom;

    public override void OnEnable() //Ovveride on enable, set state to idle
    {
        base.OnEnable();
        StateType = FSMStateType.TRANSFER;
    }
    public override bool enterState() //Enter state, once entered set duration to 0
    {
        enteredState = base.enterState();

        executor.changeRoomList();

        ChooseRoom();
        
        return enteredState;
    }

    public override void updateState() //Update state, check if we have been going too long at this point?
    {
        if (enteredState && ChosenRoom != null)
        {
            Debug.Log("Room chosen. Room: " + ChosenRoom.name);
            //Enter new chosen room.
            executor.transform.position = ChosenRoom.getEntrancePoint().gameObject.transform.position;
            executor.curPoint = ChosenRoom.getEntrancePoint();
            executor.pTime = 0f;
            executor.myRoom = ChosenRoom;
            fsm.enterState(FSMStateType.IDLE);
        }
        else
        {
            //Stay in current room, reset.
            Debug.Log("Room not selected. Resetting.");
            fsm.enterState(FSMStateType.IDLE);
            executor.pTime = 0f;
        }
    }

    public override bool exitState() //Exit the state
    {
        base.exitState();
        return true;
    }

    public void ChooseRoom()
    {
        Rooms.Clear();
        int pRow = 0;
        int pCol = 0;
        bool pfound = false;

        for (int i = 0; i < executor.rooms.rows.Length; i++)
        { 
            for (int j = 0; j < executor.rooms.rows[i].row.Length; j++)
            {
                if (executor.rooms.rows[i].row[j] == player.myRoom)
                {
                    pRow = i;
                    pCol = j;
                    pfound = true;

                    Debug.Log("Row: " + pRow.ToString() + " Col: " + pCol.ToString() + " - Room Name: " + executor.rooms.rows[i].row[j].getName());
                }
            }
        }

        if (pfound)
        {
            bool added = false;
            if (pRow - 1 >= 0)
            {
                if (executor.rooms.rows[pRow - 1].row[pCol] != null)
                {
                    Rooms.Add(executor.rooms.rows[pRow - 1].row[pCol]);
                    added = true;
                }
            }
            if (pRow + 1 < executor.rooms.rows.Length)
            {
                if (executor.rooms.rows[pRow + 1].row[pCol] != null)
                {
                    Rooms.Add(executor.rooms.rows[pRow + 1].row[pCol]);
                    added = true;
                }
            }
            if (pCol - 1 >= 0)
            {
                if (executor.rooms.rows[pRow].row[pCol - 1] != null)
                {
                    Rooms.Add(executor.rooms.rows[pRow].row[pCol - 1]);
                    added = true;
                }
            }
            if (pCol + 1 < executor.rooms.rows[pRow].row.Length)
            {
                if (executor.rooms.rows[pRow].row[pCol + 1] != null)
                {
                    Rooms.Add(executor.rooms.rows[pRow].row[pCol++]);
                    added = true;
                }
            }

            if (added)
            {
                int rand = Random.Range(0, Rooms.Count);
                ChosenRoom = Rooms[rand];

                foreach(room room in Rooms)
                {
                    Debug.Log("Room Name: " + room.getName());
                }

                if (Rooms.Count <= 2)
                {
                    if (Rooms.Count == 2)
                    {
                        if (Rooms[0] == executor.myRoom && Rooms[1] == player.myRoom)
                        {
                            Debug.Log("No room chosen. Resetting.");
                            ChosenRoom = null;
                        }
                        else if (Rooms[1] == executor.myRoom && Rooms[0] == player.myRoom)
                        {
                            Debug.Log("No room chosen. Resetting.");
                            ChosenRoom = null;
                        }
                        else
                        {
                            if(Rooms[0] == executor.myRoom || Rooms[0] == player.myRoom)
                            {
                                ChosenRoom = Rooms[1];
                            }
                            if (Rooms[1] == executor.myRoom || Rooms[1] == player.myRoom)
                            {
                                ChosenRoom = Rooms[0];
                            }
                            else
                            {
                                while (ChosenRoom == player.myRoom || ChosenRoom == executor.myRoom)
                                {
                                    rand = Random.Range(0, Rooms.Count);
                                    ChosenRoom = Rooms[rand];
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("No room chosen. Resetting.");
                        ChosenRoom = null;
                    }
                }
                else
                {
                    while (ChosenRoom == player.myRoom || ChosenRoom == executor.myRoom)
                    {
                        rand = Random.Range(0, Rooms.Count);
                        ChosenRoom = Rooms[rand];
                    }
                }
            }
        }
        else
        {
            Debug.Log("Player not found, staying in room.");
        }
    }
}
