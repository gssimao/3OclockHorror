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

        }
    }
}
