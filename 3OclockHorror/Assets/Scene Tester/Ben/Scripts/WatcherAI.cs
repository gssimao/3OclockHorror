using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherAI : MonoBehaviour
{
    public room[] Rooms;

    public GameObject player;
    public bool playerInRoom;
    public int emptyRoomCount = 0;
    public float coolDownTimer;
    public invUI inventoryUI;

    int randInd;
    bool candlesOut;
    bool timerLock = true;
    int candleNum;
    int[] candlesOn;
    float ovTimer;

    //Room Specific variables
    room currentRoom;
    Vector3 spawnPoint;
    Light[] Candles;
    room playerRoom;

    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Rooms[0];
        Candles = currentRoom.getRoomObject().GetComponentsInChildren<Light>();
        spawnPoint = currentRoom.getWatcherSpawn().transform.position;

        candleNum = Candles.Length;
        ovTimer = coolDownTimer;
        inventoryUI = player.GetComponent<invUI>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerRoom();
        CheckRoom();
        candlesOut = CheckCandles();

        if(inventoryUI.active == true)
        {
            if(!candlesOut && timerLock)// candles are not out
            {
                BlowOutCandle();
                timerLock = false;
            }
        }

        if (!candlesOut && !playerInRoom)// all candles are out and the player is not in the room
        {
            BlowOutCandle();
        }
        else if(candlesOut && !playerInRoom)
        {
            MoveWatcher();
        }

        if (timerLock == false)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if(coolDownTimer <= 0)
        {
            timerLock = true;
            coolDownTimer = ovTimer;
        }

    }
    
    void MoveWatcher()
    {
        int plyIndex;

        if (emptyRoomCount == 0)
        {
            randInd = Random.Range(0, Rooms.Length-1);

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];

            if(!playerInRoom)
            {
                emptyRoomCount++;
            }
            else
            {
                emptyRoomCount = 0;
            }
        }
        else if(emptyRoomCount == 1)
        {
            plyIndex = FindPlayerRoom();

            randInd = Random.Range(plyIndex - 2, plyIndex + 3);

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];

            if (!playerInRoom)
            {
                emptyRoomCount++;
            }
            else
            {
                emptyRoomCount = 0;
            }
        }
        else if(emptyRoomCount == 2)
        {
            plyIndex = FindPlayerRoom();

            randInd = Random.Range(plyIndex - 1, plyIndex + 2);

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];

            if (!playerInRoom)
            {
                emptyRoomCount++;
            }
            else
            {
                emptyRoomCount = 0;
            }
        }
        else// if emptyRoomCount >= 3
        {
            this.transform.position = playerRoom.getWatcherSpawn().transform.position;
            currentRoom = playerRoom;
        }
    }

    void BlowOutCandle()
    {
        int selectedAmt = Random.Range(1, candlesOn.Length + 1);
        int temp;
        Debug.Log(selectedAmt);

        for (int i = 0; i <= selectedAmt; i++)
        {
            temp = candlesOn[Random.Range(0, selectedAmt - 1)];
            Candles[temp].enabled = false;
        }
    }

    bool CheckCandles()
    {
        int candleCount = 0;
        int j = 0;

        for(int i = 0; i < candleNum; i++)
        {
            if(Candles[i].isActiveAndEnabled)
            {
                candleCount++;
            }
        }

        candlesOn = new int[candleCount];

        for(int i = 0; i < candleNum; i++)
        {
            if (Candles[i].isActiveAndEnabled)
            {
                candlesOn[j] = i;
                j++;
            }
        }
        if (candleCount > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    int FindPlayerRoom()
    {
        int plyIndex = 0;

        for(int i = 0; i <= Rooms.Length; i++)
        {
            if(Rooms[i].getName() == playerRoom.getName())
            {
                plyIndex = i;
            }
        }

        return plyIndex;
    }

    void CheckRoom()
    {
        string plyRoomName, watcherRoomName;
        plyRoomName = playerRoom.getName();
        watcherRoomName = currentRoom.getName();

        if (watcherRoomName == plyRoomName)
        {
            playerInRoom = true;
        }
        else
        {
            playerInRoom = false;
        }
    }
    
    void GetPlayerRoom()
    {
        playerRoom = player.GetComponent<room>();
    }

    void activate()
    {
        gameObject.SetActive(true);
    }
}
