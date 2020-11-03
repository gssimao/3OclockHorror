using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public string sceneName; //name of the scene to transfer too
    private Vector3 playerPosition;
    private Scene currentScene;

    public StairTransition transition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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

        transition.PlayTransition();

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(Instance, SceneManager.GetSceneByName(sceneName));

        SceneManager.UnloadSceneAsync(currentScene);
    }
}
