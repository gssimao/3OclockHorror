using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Security;
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
    public Animator watcherAnim;

    int randInd;
    public bool candlesOut;
    public bool timerLock = true;
    int candleNum;
    int[] candlesOn;
    float ovTimer;
    float distance;
    int plyIndex;
    public float plyAngle = 0;

    //Room Specific variables
    public room currentRoom;
    public CandleScript[] Candles;
    room playerRoom;
    Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Candles = currentRoom.getRoomObject().GetComponentsInChildren<CandleScript>();
        spawnPoint = currentRoom.getWatcherSpawn().transform.position;

        candleNum = Candles.Length;
        ovTimer = coolDownTimer;;
        sanityManager = player.GetComponent<SanityManager>();
        playerRoom = player.GetComponent<PlayerMovement>().myRoom;
        Debug.Log("Room Array Length: " + Rooms.Length);
    }

    // Update is called once per frame
    void Update()
    {
        playerRoom = player.GetComponent<PlayerMovement>().myRoom;
        CheckRoom();
        candlesOut = CheckCandles();
        UpdateFace();
        // False means all the candles are off or don't exist
        // True means there are still candles on

        if (inventoryUI.activeSelf == true)
        {
            if(candlesOut && timerLock)// candles are not out
            {
                BlowOutCandle();
                timerLock = false;
            }
        }

        if (candlesOut == true && !playerInRoom)// The candles are not out and the player is not in the room
        {
            BlowOutCandle();
        }
        else if(!candlesOut && !playerInRoom && timerLock)
        {
            MoveWatcher();
            timerLock = false;
        }

        if (timerLock == false)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if(coolDownTimer < 0)
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
        int i = 0;
        if (emptyRoomCount == 0)
        {
            randInd = Random.Range(0, Rooms.Length);
            
            while (currentRoom == Rooms[randInd] && i < 10) // Makes sure the Watcher does not try to teleport to the same room
            {
                randInd = Random.Range(0, Rooms.Length);
                i++;
            }

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];
            Candles = currentRoom.getRoomObject().GetComponentsInChildren<CandleScript>();
        }
        else if(emptyRoomCount == 1)
        {
            plyIndex = FindPlayerRoom();

            randInd = Random.Range(plyIndex - 2, plyIndex + 3);
            while (currentRoom == Rooms[randInd] && i < 10) // Makes sure the Watcher does not try to teleport to the same room
            {
                randInd = Random.Range(plyIndex - 2, plyIndex + 3);
            }

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];
            Candles = currentRoom.getRoomObject().GetComponentsInChildren<CandleScript>();
        }
        else if(emptyRoomCount == 2)
        {
            plyIndex = FindPlayerRoom();

            randInd = Random.Range(plyIndex - 1, plyIndex + 2);
            while (currentRoom == Rooms[randInd] && i < 10) // Makes sure the Watcher does not try to teleport to the same room
            {
                randInd = Random.Range(plyIndex - 1, plyIndex + 2);
            }

            this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            currentRoom = Rooms[randInd];
            Candles = currentRoom.getRoomObject().GetComponentsInChildren<CandleScript>();
        }
        else// if emptyRoomCount >= 3
        {
            this.transform.position = playerRoom.getWatcherSpawn().transform.position;
            currentRoom = playerRoom;
            Candles = currentRoom.getRoomObject().GetComponentsInChildren<CandleScript>();
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
            Candles[temp].CandleToggle(false);
        }
    }

    bool CheckCandles()// Checks to see if there is any candles that are on, and if there are it finds out how many there are
    {
        int candleCount = 0;
        int j = 0;

        if(Candles == null || Candles.Length == 0)
        {
            return false;
        }

        for (int i = 0; i < candleNum; i++)
        {
            if (Candles[i].flame != null)
            {
                if (Candles[i].flame.isActiveAndEnabled)
                {
                    candleCount++;
                }
            }

        }

        candlesOn = new int[candleCount];

        for(int i = 0; i < candleNum; i++)
        {
            if (Candles[i].flame != null)
            {
                if (Candles[i].flame.isActiveAndEnabled)
                {
                    candlesOn[j] = i;
                    j++;
                }
            }
        }
        if (candleCount > 0)
        {
            return true; // True means there are still candles on
        }
        else
        {
            return false; // False means all the candles are off or don't exist
        }
    }

    int FindPlayerRoom() //Finds the index of the room the player is in
    {
        int plyIndex = 0;

        for(int i = 0; i < Rooms.Length; i++)
        {
            if(Rooms[i] != playerRoom)
            {
                plyIndex = i;
            }
            /*if(i >= Rooms.Length - 1)
            {
                i = 0;
            }*/
        }

        return plyIndex;
    }

    void CheckRoom() //Checks to see if the room the watcher is in has the player
    {
        if (currentRoom == playerRoom)
        {
            playerInRoom = true;
        }
        else
        {
            playerInRoom = false;
        }
    }

    void UpdateFace()
    {
        Vector3 direction = player.transform.position - this.gameObject.transform.position;
        plyAngle = Vector3.Angle(direction, this.gameObject.transform.right);

        if(plyAngle <= 180 && plyAngle > 121)
        {
            watcherAnim.SetTrigger("Left");
        }
        else if(plyAngle <= 120 && plyAngle > 61)
        {
            watcherAnim.SetTrigger("Forward");
        }
        else if(plyAngle <= 60 && plyAngle > 0)
        {
            watcherAnim.SetTrigger("Right");
        }
    }

    void activate() //Turns on the Watcher
    {
        gameObject.SetActive(true);
    }
}
