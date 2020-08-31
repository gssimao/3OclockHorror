using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFunction : MonoBehaviour
{
    public string roomName; //name of the scene to transfer too
    private Vector3 playerPosition;
    private Scene currentScene;

    public GameObject playerPrefab;
    private GameObject controllablePlayer;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            controllablePlayer = GameObject.FindWithTag("Player");

            StartCoroutine(LoadYourAsyncScene(controllablePlayer));
        }
    }

    void OnTriggerEnter2D(Collider2D other) //Changes the scene or "Room" the player is when it hits this GameObject
    {
        if (other.tag == "Player") // checks to see if the object is the player
        {
            StartCoroutine(LoadYourAsyncScene(other.gameObject));

            other.transform.position = gameObject.transform.position;
        }
    }

    IEnumerator LoadYourAsyncScene(GameObject Instance)
    {
        currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(Instance, SceneManager.GetSceneByName(roomName));

        SceneManager.UnloadSceneAsync(currentScene);
    }
}
