using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherAI : MonoBehaviour
{
    public GameObject[] Rooms;
    public Light[] Candles;

    public GameObject player;
    public bool playerInRoom;
    public int emptyRoomCount = 0;
    public float coolDownTimer;
    public invUI inventoryUI;

    int randInd;
    //bool playerInBench;
    bool candlesOut;
    bool timerLock = true;
    int candleNum;
    int[] candlesOn;
    float ovTimer;

    // Start is called before the first frame update
    void Start()
    {
        candleNum = Candles.Length;
        ovTimer = coolDownTimer;
        inventoryUI = player.GetComponent<invUI>();
    }

    // Update is called once per frame
    void Update()
    {
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

       Debug.Log("the value of timerLock is " + timerLock);

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
        int selectedNum = Random.Range(1, candlesOn.Length);

        for(int i = 0; i <= selectedNum; i++)
        {
            Candles[candlesOn[Random.Range(0, selectedNum)]].enabled = false;
        }
    }

    bool CheckCandles()
    {
        int candleCount = 0;

        for(int i = 0; i < candleNum; i++)
        {
            if(Candles[i].isActiveAndEnabled)
            {
                candleCount++;
            }
        }

        candlesOn = new int[candleCount];

        Debug.Log("This is the value of candleCount " + candleCount);
        Debug.Log("The size of the candlesOn array is " + candlesOn.Length);

        for(int i = 0; i < candleCount; i++)
        {
            if (Candles[i].isActiveAndEnabled)
            {
                candlesOn[i] = i;
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

    void activate()
    {
        gameObject.SetActive(true);
    }
}
