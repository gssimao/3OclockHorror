using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLadder : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Inventory Pinv;
    [SerializeField]
    GameObject inCanv;
    [SerializeField]
    invInput Listener;
    [SerializeField]
    Item brokenLadder;

    bool ladTaken;
    float dist;
    float index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if(dist <= 0.7f && ladTaken == false)
        {
            Listener.isFocus = false;


        }
    }
}
