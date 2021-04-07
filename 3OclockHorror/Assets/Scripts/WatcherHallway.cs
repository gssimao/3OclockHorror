using UnityEngine;

public class WatcherHallway : MonoBehaviour
{
    [SerializeField]
    LightMatch plyMatch;
    [SerializeField]
    WatcherAI watcher;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    room eastHallway;

    [Space]
    [SerializeField]
    GameObject[] Spawns;
    [SerializeField]
    float plyAngle;

    roomCntrl thisDoor;

    bool toggle = false;
    float dist;
    float spwnDist;
    int i = 0;

    UniversalControls uControls;
    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();
    }
    private void OnDisable()
    {
        uControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        thisDoor = GetComponent<roomCntrl>();
    }

    // Update is called once per frame
    void Update()
    {
        WatchHallwaySwitch();

        dist = Vector3.Distance(this.transform.position, player.transform.position);
        if(dist <= thisDoor.range)
        {
            if(uControls.Player.Interact.triggered)
            {
                toggle = true;
            }
        }

        if(toggle)
        {
            MoveWatcherHW();
        }

        if(!toggle)
        {
            WatchHallwaySwitch();
        }
    }

    void WatchHallwaySwitch()
    {
        if (toggle)
        {
            plyMatch.enabled = false;
            watcher.WatcherHallway = true;
        }
        else
        {
            plyMatch.enabled = true;
            watcher.WatcherHallway = false;
        }
    }

    void MoveWatcherHW()
    {
        Vector3 direction = player.transform.position - watcher.transform.position;
        plyAngle = Vector3.Angle(direction, watcher.transform.right);

        watcher.transform.position = Spawns[i].transform.position;
        spwnDist = Vector3.Distance(player.transform.position, Spawns[i].transform.position);

        if (plyAngle <= 90)
        {
            if (i + 1 != Spawns.Length)
            {
                i++;
            }
        }
        else if(spwnDist > 0.7f)
        {
            if (i - 1 >= 0)
            {
                i--;
            }
        }
    }
}
