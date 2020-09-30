using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    //This class is just for maintinence of rooms and relavent variables, in order to allow quick and easy access to any of the necessary aspects of a room a character is in
    //All variables are enterable within the editor, best to maintain them there.
    [SerializeField]
    GameObject roomObject; //Object that actually serves as the room parent.
    [SerializeField]
    GameObject watcherSpawn; //Point the watcher teleports to if he goes to this room
    [SerializeField]
    GameObject entrancePoint; //Stores gameobject at door, for purposes of spawning hunter/creep
    [SerializeField]
    GameObject cameraPoint;
    [SerializeField]
    Collider2D entrance; //Collider for entrance/exit - Might be depreciated alongside entrance.
    [SerializeField]
    string roomName; //Name for the room, can serve as a way to sort them

    #region Get/Set

    public GameObject getRoomObject()
    {
        return roomObject;
    }
    public GameObject getWatcherSpawn()
    {
        return watcherSpawn;
    }
    public GameObject getEntrancePoint()
    {
        return entrancePoint;
    }
    public Collider2D getEntrance()
    {
        return entrance;
    }
    public string getName()
    {
        return roomName;
    }

    public GameObject getCameraPoint()
    {
        return cameraPoint;
    }

    #endregion
}
