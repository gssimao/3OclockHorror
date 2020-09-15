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
    bool playerInBench;
    bool candlesOut;
    int candleNum;
    int[] candlesOn;

    // Start is called before the first frame update
    void Start()
    {
        candleNum = Candles.Length;
    }

    // Update is called once per frame
    void Update()
    {
       if(inventoryUI.active == true)
       {
            candlesOut = CheckCandles();

            if(!candlesOut)// candles are not out
            {
                
            }
            else
            {

            }
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
        for(int i = 0; i <= candleNum; i++)
        {
            if(Candles[i].isActiveAndEnabled)
            {
                candlesOn[i] = i;
            }
        }
        if (candlesOn[0] != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void activate()
    {
        gameObject.SetActive(true);
    }
}
