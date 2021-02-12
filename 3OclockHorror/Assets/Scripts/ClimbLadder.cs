using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject dest;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);
        if(dist <= 0.5f)
        {
            if(Input.GetKeyDown("e"))
            {
                player.transform.position = dest.transform.position;
            }
        }
    }
}
