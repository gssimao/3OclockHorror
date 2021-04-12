using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbandonmentEffect : MonoBehaviour
{
    public bool Activate;

    [Space]
    [SerializeField]
    idleState BCIdleState;
    [SerializeField]
    WatcherAI watcher;
    [SerializeField]
    List<GameObject> beartraps;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    SanityManager sanity;

    [SerializeField]
    GameObject blindCreep;
    [SerializeField]
    GameObject trapCntrl;

    CandleScript[] Candles;
    int candleCount = 0;
    AudioManager manager;

    float gracePeriodDefault = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        candleCount = 0;

        if(Activate)
        {
            if (watcher.gameObject.activeSelf)
            {
                watcher.abandonment = true;
            }
            
            if (blindCreep.activeSelf)
            {
                BCIdleState.abandonment = true;
            }

            if (trapCntrl.activeSelf)
            {
                TurnOffBeartraps();
            }

            Candles = player.myRoom.getRoomObject().GetComponentsInChildren<CandleScript>();

            foreach (CandleScript candle in Candles)
            {
                if (candle.lightOn)
                {
                    candleCount++;
                }
            }

            if(candleCount <= 0)
            {
                sanity.ChangeSanity(-5 * Time.deltaTime/2);

                if (manager != null)
                {
                    manager.Play("Evil_Laugh", false);
                }
            }
            else
            {
                if (manager != null)
                {
                    manager.Stop("Evil_Laugh");
                }
            }
        }
    }

    void TurnOffBeartraps()
    {
        int total = 0;

        foreach(GameObject beartrap in beartraps)
        {
            if(beartrap.activeSelf)
            {
                total++;
            }
        }

        while(total > 5)
        {
            int rand = Random.Range(0, total);

            beartraps[rand].SetActive(false);

            total--;
        }
    }
}
