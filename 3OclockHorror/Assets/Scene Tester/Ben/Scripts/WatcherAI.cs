using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherAI : MonoBehaviour
{
    public GameObject[] Rooms;
    public GameObject[] Candles;

    public bool candlesOut;
    public bool playerInRoom;
    public bool playerInBench;
    public int emptyRoomCount = 0;
    public float coolDownTimer;

    int randInd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(candlesOut && !playerInRoom)
        {
            MoveWatcher();
        }
        else if(!candlesOut && playerInBench && coolDownTimer == 0)
        {

        }
    }
    
    void MoveWatcher()
    {
        if (emptyRoomCount == 0)
        {
            randInd = Random.Range(0, Rooms.Length-1);

            this.transform.position = Rooms[randInd].transform.position;
        }
        else if(emptyRoomCount == 1)
        {
            
        }
        else if(emptyRoomCount == 2)
        {

        }
        else// if emptyRoomCount >= 3
        {

        }
    }

    void BlowOutCandle()
    {
        //Get how many candles are lit in room, as well as their locations

        //Use random.range to select from 1 to all of the candles in the room to blow out

    }
}
