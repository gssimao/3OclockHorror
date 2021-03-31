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

    CandleScript[] Candles;

    float gracePeriodDefault = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Activate)
        {
            watcher.abandonment = true;

            //BCIdleState.gracePeriod = 1.5f;

            BCIdleState.abandonment = true;

            Candles = player.myRoom.getRoomObject().GetComponentsInChildren<CandleScript>();
        }
    }
}
