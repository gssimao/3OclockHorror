using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public PlayerMovement player;
    public invInput Listener;
    public GameObject invCanv;
    public FloorChanger sceneChanger;

    //Gameobject Variables
    public roomCntrl[] emptyObjectsRC;
    public ContainerControl[] emptyObjectsCC;
    public workbench_cntrl[] emptyObjectsWC;
    public CandleScript[] emptObjectsCS;
    public NPC[] emptyObjectsNPC;
    public FiniteStateMachine[] emptyObjectsFSM;
    public ClockTick[] emptyObjectsCT;
    public WatcherAI[] emptyObjectsWAI;
    public bool inputPlyBool = false;

    //Player Fields
    public Camera plyCamera;
    public GameObject transferCanvas;
    public room startRoom;
    public GameObject Watcher;
    public GameObject TheBlindCreep;
    public SanityManager sanityManager;
    public clockCntrl clockCntrl;
    public List<GameObject> plyCanvases;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.sceneCount == 1)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
                Listener = player.GetComponentInChildren<invInput>();
                clockCntrl = player.GetComponent<clockCntrl>();
                sanityManager = player.GetComponent<SanityManager>();
                invCanv = player.Canvases[0];
                player.Canvases[1].GetComponent<Canvas>().worldCamera = plyCamera;
                clockCntrl.SetWatcher(Watcher);
                clockCntrl.SetCreep(TheBlindCreep);
                player.tempCanvases.AddRange(plyCanvases);
                Listener.ClearObjsList();
                player.myRoom = startRoom;
                player.Camera = plyCamera;
                CallFindObjects();
            }
            else if (!inputPlyBool)
            {
                if (CallInputFunctions() == true)
                {
                    sceneChanger.player = player.gameObject;
                    sceneChanger.Listener = Listener;
                    inputPlyBool = true;
                }
            }
        }
    }

    #region Input Functions
    bool InputPlayerMovement(roomCntrl[] emptyObjects)
    {
        for (int i = 0; i < emptyObjects.Length; i++)
        {
            emptyObjects[i].player = player;
            emptyObjects[i].Listener = Listener;
        }
        return true;
    }
    bool InputPlayerMovement(FiniteStateMachine[] emptyObjects)
    {
        for (int i = 0; i < emptyObjects.Length; i++)
        {
            emptyObjects[i].player = player;
        }
        return true;
    }
    bool InputPlayerMovement(ContainerControl[] emptyObjects)
    {
        for (int i = 0; i < emptyObjects.Length; i++)
        {
            emptyObjects[i].setPlayerObject(player.gameObject);
            emptyObjects[i].Listener = Listener;
            emptyObjects[i].invCanv = invCanv;
            emptyObjects[i].setcntnrDisp(player.Cntnr);
            emptyObjects[i].setIM(player.charPanel);
            emptyObjects[i].settooltip(player.ToolTip);
        }
        return true;
    }
    bool InputPlayerMovement(CandleScript[] emptyObjects)
    {
        for (int i = 0; i < emptyObjects.Length; i++)
        {
            emptyObjects[i].setPlayerObject(player.gameObject);
        }
        return true;
    }
    bool InputPlayerMovement(workbench_cntrl[] emptyObjects)
    {
        for (int i = 0; i < emptyObjects.Length; i++)
        {
            emptyObjects[i].setPlayerObject(player.gameObject);
            emptyObjects[i].Listener = Listener;
            emptyObjects[i].invCanv = invCanv;
            emptyObjects[i].setmyInvDisplay(player.wbInventory);
            emptyObjects[i].setIM(player.charPanel);
            emptyObjects[i].settooltip(player.ToolTip);
        }
        return true;
    }
    bool InputPlayerMovement(NPC[] emptyObjects)
    {
        for (int i = 0; i < emptyObjects.Length; i++)
        {
            emptyObjects[i].player = player.gameObject;
        }
        return true;
    }
    bool InputPlayerMovement(ClockTick[] emptyObjects)
    {
        for (int i = 0; i < emptyObjects.Length; i++)
        {
            emptyObjects[i].player = player.gameObject;
        }
        return true;
    }
    bool InputPlayerMovement(WatcherAI[] emptyObjects)
    {
        for (int i = 0; i < emptyObjects.Length; i++)
        {
            emptyObjects[i].player = player.gameObject;
            emptyObjects[i].inventoryUI = invCanv;
            emptyObjects[i].sanityManager = sanityManager;
        }
        return true;
    }
    #endregion

    void CallFindObjects()
    {
        //Gameobject Functions
        emptyObjectsRC = FindObjectsOfType<roomCntrl>();
        emptyObjectsCC = FindObjectsOfType<ContainerControl>();
        emptyObjectsWC = FindObjectsOfType<workbench_cntrl>();
        emptObjectsCS = FindObjectsOfType<CandleScript>();
        emptyObjectsFSM = FindObjectsOfType<FiniteStateMachine>();
        emptyObjectsNPC = FindObjectsOfType<NPC>();
        emptyObjectsCT = FindObjectsOfType<ClockTick>();
        emptyObjectsWAI = FindObjectsOfType<WatcherAI>();
    }

    bool CallInputFunctions()
    {
        if (
        InputPlayerMovement(emptyObjectsRC) == true &&
        InputPlayerMovement(emptyObjectsCC) == true &&
        InputPlayerMovement(emptyObjectsWC) == true &&
        InputPlayerMovement(emptObjectsCS) == true &&
        InputPlayerMovement(emptyObjectsFSM) == true &&
        InputPlayerMovement(emptyObjectsNPC) == true &&
        InputPlayerMovement(emptyObjectsCT) == true &&
        InputPlayerMovement(emptyObjectsWAI) == true
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*IEnumerator PerformInputFunctions()
    {
        AsyncOperation asyncload;

        while(!asyncload.isDone)
        {
        }

    }*/
}
