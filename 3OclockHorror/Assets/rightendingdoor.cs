using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightendingdoor : MonoBehaviour
{
    //The background data for the door to work
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    GameObject tpPoint;
    [SerializeField]
    room room;
    public invInput Listener;
    public Tooltip toolTipScript;

    [Space] //The key for the door
    public bool locked;
    public Inventory pInv;
    public Item MyKey;

    //The symbols for the door
    [Space]
    [SerializeField]
    List<symbolUpdater> symbols;

    AudioManager manager;

    public Animator Fade;

    bool opened = false;
    public bool transitionOnOff = true; //Use this toggle the transition on and off
    float transitionTime = 0.5f;

    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.gameObject.transform.position, this.gameObject.transform.position);
        if (dist <= 1f)
        {
            Listener.isFocus = false;
            if (Input.GetKeyDown("e") && transitionOnOff)
            {
                if(locked)
                {
                    CheckKey();
                }

                if (player != null && !locked) //Make sure it's not null, check if door is locked
                {
                    CameraCrossfade(player.gameObject, tpPoint, player, room);
                    if (manager != null)
                    {
                        manager.Play("Door Open", true);
                    }
                }
            }
        }
    }

    public void CheckKey()
    {
        if (pInv != null && MyKey != null)
        {
            if (pInv.ContainsItem(MyKey))
            {
                locked = false;
                foreach (symbolUpdater sym in symbols)
                {
                    if (!sym.active)
                    {
                        locked = true;
                    }
                }
            }

            if (locked)
            {
                toolTipScript.UpdateTooltipMessage("This door is locked.");
                if (manager != null)
                {
                    manager.Play("Locked Door", false);
                }
            }
        }
        else
        {
            toolTipScript.UpdateTooltipMessage("This door is locked.");
            Debug.LogError("Door is locked but there is no key or inv set");
        }
    }

    public void CameraCrossfade(GameObject player, GameObject entranceP, PlayerMovement play, room RoomNum)
    {
        StartCoroutine(ChangeCamera(player, entranceP, play, RoomNum));
    }

    IEnumerator ChangeCamera(GameObject player, GameObject entranceP, PlayerMovement play, room RoomNum)
    {
        if (transitionOnOff)
        {
            Fade.gameObject.SetActive(true);
            Fade.SetTrigger("fadeOut");
        }

        player.transform.position = entranceP.transform.position;

        if (transitionOnOff)
        {
            yield return new WaitForSeconds(transitionTime);
            Fade.SetTrigger("fadeIn");
        }

        play.myRoom = RoomNum;
    }
}
