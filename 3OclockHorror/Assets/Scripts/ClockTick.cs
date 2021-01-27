using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTick : MonoBehaviour
{
    public GameObject player;
    public GameObject GrandfatherClock;

    public float soundRange;
    bool isPlaying;
    float dist;

    AudioManager manager; //Bake it up here, helps to reduce stack time

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>(); //Then the baked instance can be set during start, so it only happens on load time but then is always there
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        Debug.Log("Clock Dist: " + dist);

        if (manager != null) //Then just gotta add a new if to make sure manager isn't null (always good practice to have such a thing)
        {
            if (dist <= soundRange)
            {
                //FindObjectOfType<AudioManager>().Play("Clock Tick");
                playSound();
            }
            else
            {
                //FindObjectOfType<AudioManager>().Stop("Clock Tick");
                manager.Stop("Clock Tick");
            }
        }
    }

    void playSound()
    {
        if (!isPlaying)
        {
            manager.Play("Clock Tick");
            isPlaying = true;
        }
    }
}
