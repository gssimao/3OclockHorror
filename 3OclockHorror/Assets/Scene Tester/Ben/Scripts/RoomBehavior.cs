using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior : room
{
    public Light[] Candles;

    public bool playerInRoom;
    public GameObject player;
    public GameObject maxPos;
    public GameObject minPos;

    GameObject roomObject;
    // Start is called before the first frame update
    void Start()
    {
        roomObject = getRoomObject();
        Candles = roomObject.GetComponentsInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if //This checks to see if the player is within the area marked by the maxPos and minPos game objects
            (
                player.transform.position.x > minPos.transform.position.x &&
                player.transform.position.x < maxPos.transform.position.x &&
                player.transform.position.y > minPos.transform.position.y &&
                player.transform.position.y < maxPos.transform.position.y &&
                player.transform.position.z > minPos.transform.position.z &&
                player.transform.position.z < maxPos.transform.position.z
            )
        {
            playerInRoom = true;
        }
        else
        {
            playerInRoom = false;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube();
    }*/
}
