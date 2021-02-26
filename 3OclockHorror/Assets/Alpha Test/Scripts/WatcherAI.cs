using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class WatcherAI : MonoBehaviour
{
    public room[] floor3Rooms;
    public room[] floor2Rooms;
    public room[] floor1Rooms;
    public room[] Rooms;

    public GameObject player;
    public bool playerInRoom;
    public int emptyRoomCount = 0;
    public float coolDownTimer;
    public GameObject inventoryUI;
    public SanityManager sanityManager;
    public Animator watcherAnim;

    int randInd;
    public bool candlesOut;
    public bool isPlaying = false;
    public bool isFarPlaying = false;
    public bool isClosePlaying = false;
    public bool isScreamPlaying = false;
    public bool timerLock = true;
    int[] candlesOn;
    float ovTimer;
    float distance;
    int plyIndex;
    public float plyAngle = 0;
    public bool WatcherHallway = false;

    //Room Specific variables
    public room currentRoom;
    public CandleScript[] Candles;
    room playerRoom;
    AudioManager manager;

    //Watcher Hallway Variables
    [Space]
    [SerializeField]
    room eastHallway;
    [SerializeField]
    GameObject startPoint;
    [SerializeField]
    GameObject[] Spawns;
    int i;
    float spwnDist;

    // Start is called before the first frame update
    void Start()
    {
        Rooms = floor1Rooms;
        Candles = currentRoom.getRoomObject().GetComponentsInChildren<CandleScript>();

        ovTimer = coolDownTimer;;
        sanityManager = player.GetComponent<SanityManager>();
        playerRoom = player.GetComponent<PlayerMovement>().myRoom;
        manager = FindObjectOfType<AudioManager>();

        Debug.Log("Watcher Current Room: " + currentRoom.name);
    }

    // Update is called once per frame
    void Update()
    {
        playerRoom = player.GetComponent<PlayerMovement>().myRoom;
        CheckRoom();
        UpdateFace();
        candlesOut = CheckCandles();
        // candlesOut Explaination:
        // False means all the candles are off or don't exist
        // True means there are still candles on

        if (inventoryUI.activeSelf == true)
        {
            if(candlesOut && timerLock)// candles are not out
            {
                BlowOutCandle();
                timerLock = false;
            }
        }

        if (WatcherHallway == true)
        {
            MoveWatcherHW();
        }
        else
        {
            if (candlesOut && !playerInRoom)// The candles are not out and the player is not in the room
            {
                BlowOutCandle();
            }
            else if (!candlesOut && !playerInRoom && timerLock)
            {
                MoveWatcher();
                timerLock = false;
                Debug.Log("Watcher Current Room: " + currentRoom.name);
            }
        }

        if (timerLock == false)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if(coolDownTimer < 0)
        {
            timerLock = true;
            coolDownTimer = ovTimer;
        }

        if (playerInRoom)
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);

            if (distance <= 0.4)
            {
                if (!WatcherHallway)
                {
                    sanityManager.ChangeSanity(-2 * Time.deltaTime);
                }
                else
                {
                    sanityManager.ChangeSanity(-5);

                    player.transform.position = startPoint.transform.position;
                }

                if (manager != null && isClosePlaying == true)
                {
                    manager.Stop("Watcher Close");
                    isClosePlaying = false;
                }

                else if (isScreamPlaying == false && manager != null)
                {
                    manager.Play("Watcher Scream", true);
                    isScreamPlaying = true;
                }
                else isScreamPlaying = false;
            }
            else if (distance <= 0.6) //Player is very close to Watcher
            {
                if (manager != null && isFarPlaying == true)
                {
                    manager.Stop("Watcher Far");
                    isFarPlaying = false;
                }

                else if (isClosePlaying == false && manager != null)
                {
                    manager.Play("Watcher Close", false);
                    isClosePlaying = true;
                }

                else isClosePlaying = false;
            }
            else if (distance <= 1.25) //Player is getting closer to Watcher
            {
                if (manager != null && isClosePlaying == true)
                {
                    manager.Stop("Watcher Close");
                    isClosePlaying = false;
                }
                else if (isFarPlaying == false && manager != null)
                {
                    manager.Play("Watcher Far", false);
                    isFarPlaying = true;
                }
                else isFarPlaying = false;
            }
            else
            {
                if (manager != null && isScreamPlaying == true)
                {
                    manager.Stop("Watcher Scream");
                    isScreamPlaying = false;
                }
                else if (manager != null && isFarPlaying == true)
                {
                    manager.Stop("Watcher Far");
                    isFarPlaying = false;
                }
                else if (manager != null && isClosePlaying == true)
                {
                    manager.Stop("Watcher Close");
                    isClosePlaying = false;
                }
            }

        }
    }

    void MoveWatcher() //Moves the watcher between the rooms
    {
        CheckRoom();

        if (emptyRoomCount == 0)
        {
            int i = 0;
            randInd = Random.Range(0, Rooms.Length);
            while (currentRoom == Rooms[randInd] && i < 10) // Makes sure the Watcher does not try to teleport to the same room
            {
                randInd = Random.Range(0, Rooms.Length);
                i++;
            }

            ChangeRoom(Rooms[randInd]);
        }
        else if(emptyRoomCount == 1)
        {
            plyIndex = FindPlayerRoom();

            int i = 0;
            randInd = Random.Range(0, Rooms.Length);
            while (currentRoom == Rooms[randInd] && i < 10) // Makes sure the Watcher does not try to teleport to the same room
            {
                randInd = Random.Range(0, Rooms.Length);
                i++;
            }

            ChangeRoom(Rooms[randInd]);
        }
        else if(emptyRoomCount == 2)
        {
            plyIndex = FindPlayerRoom();

            int i = 0;
            randInd = Random.Range(0, Rooms.Length);
            while (currentRoom == Rooms[randInd] && i < 10) // Makes sure the Watcher does not try to teleport to the same room
            {
                randInd = Random.Range(0, Rooms.Length);
                i++;
            }

            if (Rooms[randInd].getWatcherSpawn() != null)
            {
                this.transform.position = Rooms[randInd].getWatcherSpawn().transform.position;
            }
            ChangeRoom(Rooms[randInd]);
        }
        else// if emptyRoomCount >= 3
        {
            ChangeRoom(playerRoom);
        }

        CheckRoom();

        if (!playerInRoom)
        {
            emptyRoomCount++;
        }
        else
        {
            emptyRoomCount = 0;
        }
    }

    void BlowOutCandle()// Blows out the candles, from 1 candle to all the candles
    {
        int selectedAmt = Random.Range(1, candlesOn.Length + 1);
        int temp;

        if (manager != null)
        {
            manager.Play("Candle Blow Out", true);
        }

        for (int i = 0; i <= selectedAmt; i++)
        {
            temp = candlesOn[Random.Range(0, selectedAmt - 1)];
            Candles[temp].CandleToggle(false);
        }
    }

    bool CheckCandles()// Checks to see if there is any candles that are on, and if there are it finds out how many there are
    {
        int candleCount = 0;
        int j = 0;

        if(Candles == null || Candles.Length == 0)
        {
            return false;
        }

        foreach (CandleScript candle in Candles)
        {
            if (candle.flame != null)
            {
                if (candle.flame.isActiveAndEnabled)
                {
                    candleCount++;
                }
            }

        }

        candlesOn = new int[candleCount];

        for(int i = 0; i < Candles.Length; i++)
        {
            if (Candles[i].flame != null)
            {
                if (Candles[i].flame.isActiveAndEnabled)
                {
                    candlesOn[j] = i;
                    j++;
                }

            }
        }
        if (candleCount > 0)
        {
            return true; // True means there are still candles on
        }
        else
        {
            return false; // False means all the candles are off or don't exist
        }
    }

    int FindPlayerRoom() //Finds the index of the room the player is in
    {
        int plyIndex = 0;

        for(int i = 0; i < Rooms.Length; i++)
        {
            if(Rooms[i] != playerRoom)
            {
                plyIndex = i;
            }
        }

        return plyIndex;
    }

    void CheckRoom() //Checks to see if the room the watcher is in has the player
    {
        if (currentRoom == playerRoom)
        {
            playerInRoom = true;
        }
        else
        {
            if (currentRoom.getFloorNum() != playerRoom.getFloorNum())
            {
                ChangeFloor(playerRoom.getFloorNum());
            }
            else
            {
                playerInRoom = false;
            }
        }
    }

    void ChangeRoom(room target)
    {
        this.transform.position = target.getWatcherSpawn().transform.position;
        currentRoom = target;
        Candles = currentRoom.getRoomObject().GetComponentsInChildren<CandleScript>();
    }

    void UpdateFace()
    {
        Vector3 direction = player.transform.position - this.gameObject.transform.position;
        plyAngle = Vector3.Angle(direction, this.gameObject.transform.right);

        if(plyAngle <= 180 && plyAngle > 121)
        {
            watcherAnim.SetTrigger("Left");
        }
        else if(plyAngle <= 120 && plyAngle > 61)
        {
            watcherAnim.SetTrigger("Forward");
        }
        else if(plyAngle <= 60 && plyAngle > 0)
        {
            watcherAnim.SetTrigger("Right");
        }
    }

    void ChangeFloor(int floorNum)
    {
        switch (floorNum)
        {
            case 1:
                Rooms = floor1Rooms;
                break;
            case 2:
                Rooms = floor2Rooms;
                break;
            case 3:
                Rooms = floor3Rooms;
                break;
            default:
                Rooms = floor1Rooms;
                break;
        }
    }

    void MoveWatcherHW()
    {
        this.transform.position = Spawns[i].transform.position;
        spwnDist = Vector3.Distance(player.transform.position, Spawns[i].transform.position);

        if (plyAngle <= 90)
        {
            if (i + 1 != Spawns.Length)
            {
                i++;
            }
        }
        else if (spwnDist > 0.7f)
        {
            if (i - 1 >= 0)
            {
                i--;
            }
        }
    }

    void activate() //Turns on the Watcher
    {
        gameObject.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach(GameObject spawn in Spawns)
        {
            Gizmos.DrawWireSphere(spawn.transform.position, 1.25f);
        }

        Gizmos.color = Color.yellow;
        foreach (GameObject spawn in Spawns)
        {
            Gizmos.DrawWireSphere(spawn.transform.position, 0.6f);
        }

        Gizmos.color = Color.red;
        foreach (GameObject spawn in Spawns)
        {
            Gizmos.DrawWireSphere(spawn.transform.position, 0.4f);
        }
    }
}
