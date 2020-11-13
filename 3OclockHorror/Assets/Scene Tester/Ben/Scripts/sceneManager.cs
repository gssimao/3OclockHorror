using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public PlayerMovement player;

    public roomCntrl[] emptyObjectsRC;
    public ContainerControl[] emptyObjectsCC;
    public workbench_cntrl[] emptyObjectsWC;
    public CandleScript[] emptObjectsCS;
    public bool inputPlyBool = false;

    public Scene currentScene;
    public string sceneName;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        emptyObjectsRC = FindObjectsOfType<roomCntrl>();
        emptyObjectsCC = FindObjectsOfType<ContainerControl>();
        emptyObjectsWC = FindObjectsOfType<workbench_cntrl>();
        emptObjectsCS = FindObjectsOfType<CandleScript>();
    }
    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (!inputPlyBool)
        {
            if (
                InputPlayerMovement(emptyObjectsRC) == true &&// Inputs player into roomCntrl
            InputPlayerMovement(emptyObjectsCC) == true &&// Inputs player into ContainerControl
            InputPlayerMovement(emptyObjectsWC) == true &&// Inputs player into workbench_cntrl
            InputPlayerMovement(emptObjectsCS) == true// Inputs player into CandleScript
            )
            {
                inputPlyBool = true;
            }
        }
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        //throw new System.NotImplementedException();
        Debug.Log("We Changed Scenes");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        emptyObjectsRC = FindObjectsOfType<roomCntrl>();
        emptyObjectsCC = FindObjectsOfType<ContainerControl>();
        emptyObjectsWC = FindObjectsOfType<workbench_cntrl>();
        emptObjectsCS = FindObjectsOfType<CandleScript>();
    }

    bool InputPlayerMovement(roomCntrl[] emptyObjects)
    {
        bool isNULL = true;
        int i = 0;

        while (isNULL == true || i < emptyObjects.Length)
        {
            if (emptyObjects[i].player != null)
            {
                isNULL = false;
                break;
            }
            i++;
        }

        if (isNULL == true)
        {
            for (i = 0; i < emptyObjects.Length; i++)
            {
                emptyObjects[i].player = player;
            }
            return true;
        }
        else
        {
            return true;
        }
    }

    bool InputPlayerMovement(ContainerControl[] emptyObjects)
    {
        bool isNULL = true;
        int i = 0;

        while (isNULL == true || i < emptyObjects.Length)
        {
            if (emptyObjects[i].getPlayerObject() != null)
            {
                isNULL = false;
                break;
            }
            i++;
        }

        if (isNULL == true)
        {
            for (i = 0; i < emptyObjects.Length; i++)
            {
                emptyObjects[i].setPlayerObject(player.gameObject);
            }
            return true;
        }
        else
        {
            return true;
        }
    }
    bool InputPlayerMovement(CandleScript[] emptyObjects)
    {
        bool isNULL = true;
        int i = 0;

        while (isNULL == true || i < emptyObjects.Length)
        {
            if (emptyObjects[i].getPlayerObject() != null)
            {
                isNULL = false;
                break;
            }
            i++;
        }

        if (isNULL == true)
        {
            for (i = 0; i < emptyObjects.Length; i++)
            {
                emptyObjects[i].setPlayerObject(player.gameObject);
            }
            return true;
        }
        else
        {
            return true;
        }
    }

    bool InputPlayerMovement(workbench_cntrl[] emptyObjects)
    {
        bool isNULL = true;
        int i = 0;

        while (isNULL == false || i < emptyObjects.Length)
        {
            if (emptyObjects[i].getPlayerObject() != null)
            {
                isNULL = false;
                break;
            }
            i++;
        }

        if (isNULL == true)
        {
            for (i = 0; i < emptyObjects.Length; i++)
            {
                emptyObjects[i].setPlayerObject(player.gameObject);
            }
            return true;
        }
        else
        {
            return true;
        }
    }
}
