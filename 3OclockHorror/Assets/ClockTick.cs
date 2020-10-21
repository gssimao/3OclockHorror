using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTick : MonoBehaviour
{
    public GameObject player;
    public GameObject GrandfatherClock;

    public float soundRange;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);

        if (dist <= soundRange)
        {
            FindObjectOfType<AudioManager>().Play("Clock Tick");
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("Clock Tick");
        }
    }
}
