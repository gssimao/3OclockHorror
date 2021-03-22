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
    GameObject[] watcherSpawn; //Point the watcher teleports to if he goes to this room
    [SerializeField]
    connectedPatrolPoint entrancePoint; //Stores gameobject at door, for purposes of spawning hunter/creep
    [SerializeField]
    GameObject cameraPoint;
    [SerializeField]
    Collider2D entrance; //Collider for entrance/exit - Might be depreciated alongside entrance.
    [SerializeField]
    string roomName; //Name for the room, can serve as a way to sort them
    public int floorNum; //What number of floor the room is on. Basement is zero

    #region Get/Set

    public GameObject getRoomObject()
    {
        return roomObject;
    }
    public GameObject getWatcherSpawn()
    {
        int i = 0;
        
        i = Random.Range(0, watcherSpawn.Length);

        return watcherSpawn[i];
    }
    public connectedPatrolPoint getEntrancePoint()
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
    public int getFloorNum()
    {
        return floorNum;
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (GameObject Spawn in watcherSpawn)
        {
            Gizmos.DrawWireSphere(Spawn.transform.position, 0.2f);
        }
    }
}
