using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickScript : MonoBehaviour
{
    public GameObject player;
    public GameObject clock;
    public float interRange;
    float dist;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);

        if (dist <= interRange)
        {
            FindObjectOfType<AudioManager>().Play("ClockTick");
        }
        else FindObjectOfType<AudioManager>().Stop("ClockTick");

    }
}
