using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FiniteStateMachine))]
public class BlindCreepCntrl : MonoBehaviour
{
    //Public (editor assigned) Variables
    public GameObject player; //The player target for the Blind Creep to head towards / check against
    //Watcher reference as well perhaps?

    //Internals
    FiniteStateMachine fsm;

    // Start is called before the first frame update
    void Start()
    {
        fsm = this.GetComponent<FiniteStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
