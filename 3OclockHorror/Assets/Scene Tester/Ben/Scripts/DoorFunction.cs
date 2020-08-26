using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFunction : MonoBehaviour
{
    public string roomName; //name of the scene to transfer too
    private Vector3 playerPosition;
    private Scene currentScene;

    public GameObject TestObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            TestObject = GameObject.FindWithTag("Player");

            StartCoroutine(LoadYourAsyncScene());
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadYourAsyncScene()); //Changes the scene or "Room" the player is when it hits this GameObject

            other.transform.position = gameObject.transform.position; //Changes the position of the player so that it sits in the door way
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(TestObject, SceneManager.GetSceneByName(roomName));

        SceneManager.UnloadSceneAsync(currentScene);
    }
}
