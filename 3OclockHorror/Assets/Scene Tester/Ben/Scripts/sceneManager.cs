using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public string sceneName; //name of the scene to transfer too
    private Vector3 playerPosition;
    private Scene currentScene;
    public PlayerMovement player;

    public roomCntrl[] emptyObjectsRC;
    public ContainerControl[] emptyObjectsCC;
    public workbench_cntrl[] emptyObjectsWC;
    public CandleScript[] emptObjectsCS;
    public bool inputPlyBool = false;

    public GameObject stairTransition;
    public Animator Slide;

    // Start is called before the first frame update
    void Start()
    {
        stairTransition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            emptyObjectsRC = FindObjectsOfType<roomCntrl>();
            emptyObjectsCC = FindObjectsOfType<ContainerControl>();
            emptyObjectsWC = FindObjectsOfType<workbench_cntrl>();
            emptObjectsCS = FindObjectsOfType<CandleScript>();
        }
        /*else if(!inputPlyBool)
        {
            inputPlyBool = InputPlayerMovement();
        }*/

        if(Slide.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            stairTransition.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other) //Changes the scene or "Floor" the player is when it hits this GameObject
    {
        if (other.tag == "Player") // checks to see if the object is the player
        {
            StartCoroutine(LoadYourAsyncScene(other.gameObject));
        }
    }

    IEnumerator LoadYourAsyncScene(GameObject Instance)
    {
        currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Slide.SetTrigger("Start");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(Instance, SceneManager.GetSceneByName(sceneName));

        SceneManager.UnloadSceneAsync(currentScene);
    }

    bool InputPlayerMovement(roomCntrl[] emptyObjects)
    {
        bool isNULL = false;
        int i = 0;

        while(isNULL == false || i < emptyObjects.Length)
        {
            if(emptyObjects[i] == null)
            {
                isNULL = true;
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
            return false;
        }
    }

    bool InputPlayerMovement(ContainerControl[] emptyObjects)
    {
        bool isNULL = false;
        int i = 0;

        while (isNULL == false || i < emptyObjects.Length)
        {
            if (emptyObjects[i] == null)
            {
                isNULL = true;
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
            return false;
        }
    }
    bool InputPlayerMovement(CandleScript[] emptyObjects)
    {
        bool isNULL = false;
        int i = 0;

        while (isNULL == false || i < emptyObjects.Length)
        {
            if (emptyObjects[i] == null)
            {
                isNULL = true;
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
            return false;
        }
    }

    bool InputPlayerMovement(workbench_cntrl[] emptyObjects)
    {
        bool isNULL = false;
        int i = 0;

        while (isNULL == false || i < emptyObjects.Length)
        {
            if (emptyObjects[i] == null)
            {
                isNULL = true;
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
            return false;
        }
    }
}
