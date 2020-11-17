using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; //name of the scene to transfer too
    Scene currentScene;
    public GameObject spawnPoint;
    public GameObject player;
    public invInput Listener;

    public GameObject stairTransition;
    public Animator Slide;
    public string curSceneName;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        stairTransition.SetActive(false);
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
                StartCoroutine(LoadYourAsyncScene(player));
                player.transform.position = spawnPoint.transform.position;
            }
        }
        else
        {
            if (Listener != null)
            {
                Listener.enabled = true;
            }
        }
        /*if(Slide.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            stairTransition.SetActive(false);
        }*/

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //throw new NotImplementedException();

        Debug.Log("We Changed Scenes");
    }

    IEnumerator LoadYourAsyncScene(GameObject Instance)
    {
        stairTransition.SetActive(true);
        Slide.SetTrigger("Start");

        currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(currentScene);

        SceneManager.MoveGameObjectToScene(Instance, SceneManager.GetSceneByName(sceneName));
    }
}
