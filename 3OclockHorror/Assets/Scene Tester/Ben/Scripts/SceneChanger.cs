using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; //name of the scene to transfer too
    private Vector3 playerPosition;
    private Scene currentScene;

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

        SceneManager.UnloadSceneAsync(currentScene);

        SceneManager.MoveGameObjectToScene(Instance, SceneManager.GetSceneByName(sceneName));
    }
}
