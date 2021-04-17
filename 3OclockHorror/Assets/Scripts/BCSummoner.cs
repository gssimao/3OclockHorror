using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCSummoner : MonoBehaviour
{
    [SerializeField]
    GameObject BlindCreep;
    NPC BCNPC;
    [Space]
    [SerializeField]
    room TPRoom;
    [SerializeField]
    GameObject TPPoint;
    [SerializeField]
    ContainerControl ItemContainer;
    [SerializeField]
    Item trigger;

    AudioManager manager;
    public PlayerMovement player;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        BCNPC = BlindCreep.GetComponent<NPC>();
        if(BCNPC == null)
        {
            Debug.LogError("Game object provided as Blind Creep for Summoner script attached to " + gameObject.name + " did not have a NPC script attached.");
        }

        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ItemContainer.getActive() == true && BlindCreep.activeSelf)
        {
            active = true;
        }
        else if (active)
        {
            bool found = ItemContainer.containsItem(trigger);

            if (!found)
            {//Tp the Blind Creep into the desired location, adjust state/room as well.
                TPBlindCreep();
            }
            active = false;
        }
    }

    public void TPBlindCreep()
    {
        Debug.Log("Item not found");

        BCNPC.forceStateChangeIdle();
        BCNPC.myRoom = TPRoom;

        BlindCreep.transform.position = TPPoint.transform.position;
        Debug.Log("TP BC");

        if (manager != null && player.myRoom == BCNPC.myRoom)
        {
            manager.Play("Watcher room", true);
        }
    }
}
