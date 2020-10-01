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
    public GameObject inventoryUI;
    public SanityManager sanityManager;

    int randInd;
    bool candlesOut;
    bool timerLock = true;
    int candleNum;
    int[] candlesOn;
    float ovTimer;
    float distance;

    //Room Specific variables
    public room currentRoom;
    Vector3 spawnPoint;
    public Light[] Candles;
    room playerRoom;

    // Start is called before the first frame update
    void Start()
    {
        Candles = currentRoom.getRoomObject().GetComponentsInChildren<Light>();
        spawnPoint = currentRoom.getWatcherSpawn().transform.position;

        candleNum = Candles.Length;
        ovTimer = coolDownTimer;;
        sanityManager = player.GetComponent<SanityManager>();
        playerRoom = player.GetComponent<PlayerMovement>().myRoom;
    }

    // Update is called once per frame
    void Update()
    {
        playerRoom = player.GetComponent<PlayerMovement>().myRoom;
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
        else if(candlesOut && !playerInRoom && timerLock)
        {
            MoveWatcher();
            timerLock = false;
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

        if (playerInRoom)
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);

            if (distance <= 0.4)
            {
                sanityManager.ChangeSanity(-2 * Time.deltaTime);
            }
        }
    }
    
    void MoveWatcher() //Moves the watcher between the rooms
    {
        int plyIndex;

        if (emptyRoomCount == 0)
        {
            randInd = Random.Range(0, Rooms.Length);
            while (currentRoom == Rooms[randInd])
            {
                randInd = Random.Range(0, Rooms.Length);
            }

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];
            Candles = currentRoom.getRoomObject().GetComponentsInChildren<Light>();
        }
        else if(emptyRoomCount == 1)
        {
            plyIndex = FindPlayerRoom();

            randInd = Random.Range(plyIndex - 2, plyIndex + 3);
            while (currentRoom == Rooms[randInd])
            {
                randInd = Random.Range(plyIndex - 2, plyIndex + 3);
            }

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];
            Candles = currentRoom.getRoomObject().GetComponentsInChildren<Light>();
        }
        else if(emptyRoomCount == 2)
        {
            plyIndex = FindPlayerRoom();

            randInd = Random.Range(plyIndex - 1, plyIndex + 2);
            while (currentRoom == Rooms[randInd])
            {
                randInd = Random.Range(plyIndex - 1, plyIndex + 2);
            }

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];
            Candles = currentRoom.getRoomObject().GetComponentsInChildren<Light>();
        }
        else// if emptyRoomCount >= 3
        {
            this.transform.position = playerRoom.getWatcherSpawn().transform.position;
            currentRoom = playerRoom;
            Candles = currentRoom.getRoomObject().GetComponentsInChildren<Light>();
        }

        CheckRoom();
        if (!playerInRoom)
        {
            emptyRoomCount++;
        }
        else
        {
            emptyRoomCount = 0;
        }
    }

    void BlowOutCandle()// Blows out the candles, from 1 candle to all the candles
    {
        int selectedAmt = Random.Range(1, candlesOn.Length + 1);
        int temp;

        for (int i = 0; i <= selectedAmt; i++)
        {
            temp = candlesOn[Random.Range(0, selectedAmt - 1)];
            Candles[temp].enabled = false;
        }
    }

    bool CheckCandles()// Checks to see if there is any candles that are on, and if there are it finds out how many there are
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

    int FindPlayerRoom() //Finds the index of the room the player is in
    {
        int plyIndex = 0;

        for(int i = 0; Rooms[i] != playerRoom; i++)
        {
            plyIndex = i;
        }

        return plyIndex;
    }

    void CheckRoom() //Checks to see if the room the watcher is in has the player
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

    void activate() //Turns on the Watcher
    {
        gameObject.SetActive(true);
    }
}
