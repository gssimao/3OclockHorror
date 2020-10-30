using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door3D : MonoBehaviour
{
    public string roomName; //name of the scene to transfer too
    private Vector3 playerPosition;
    private Scene currentScene;

    public GameObject playerPrefab;
    private GameObject controllablePlayer;

    void OnTriggerEnter(Collider other) //Changes the scene or "Room" the player is when it hits this GameObject
    {

        if (other.tag == "Player") // checks to see if the object is the player
        {
            StartCoroutine(LoadYourAsyncScene(other.gameObject)); //Start Ienumerator function below

            other.transform.position = gameObject.transform.position; //Sets the Player position in the new scene to the same as the "door"

        }
    }

    IEnumerator LoadYourAsyncScene(GameObject Instance)
    {
        currentScene = SceneManager.GetActiveScene(); //Get the current scene

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive); //Add the scene specified by door room name to the loaded scenes

        while (!asyncLoad.isDone) //Makes it so nothing else is done until scene is loaded - aka no code can be executed outside of loop
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(Instance, SceneManager.GetSceneByName(roomName)); //Move the instance (Player) to the newly loaded scene

        SceneManager.UnloadSceneAsync(currentScene); //Unload the current scene
    }
}