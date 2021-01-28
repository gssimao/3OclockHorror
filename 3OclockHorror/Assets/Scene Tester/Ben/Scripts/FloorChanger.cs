using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChanger : MonoBehaviour
{
    public string sceneName; //name of the scene to transfer too
    Scene currentScene;
    public GameObject spawnPoint;
    public GameObject player;
    public invInput Listener;
    public room destRoom;

    public Animator transition;
    public Animator blackWallanim;
    public GameObject crossFade;
    public GameObject blackWall;

    [SerializeField]
    string destString;

    float dist;
    bool animIsDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (Mathf.Abs(dist) <= 0.6f)
        {
            Listener.enabled = false;
            if (Input.GetKeyDown("e"))
            {
                blackWall.SetActive(true);
                crossFade.SetActive(true);
                transition.SetTrigger("End");
                animIsDone = true;
                player.transform.position = spawnPoint.transform.position;
                player.GetComponent<PlayerMovement>().myRoom = destRoom;
                player.GetComponent<PlayerMovement>().playerFloor = destString;
            }
            /*if (blackWallanim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85 && animIsDone)
            {
                player.GetComponent<PlayerMovement>().tempCanvases.Clear();
                animIsDone = false;
                StartCoroutine(LoadYourAsyncScene(player));
            }*/
        }
        else
        {
            if (Listener != null)
            {
                Listener.enabled = true;
            }
        }
    }

    IEnumerator LoadYourAsyncScene(GameObject Instance)
    {
        currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        player.transform.position = spawnPoint.transform.position;
        blackWall.SetActive(false);
        crossFade.SetActive(false);

        SceneManager.MoveGameObjectToScene(Instance, SceneManager.GetSceneByName(sceneName));

        SceneManager.UnloadSceneAsync(currentScene);
    }
}
