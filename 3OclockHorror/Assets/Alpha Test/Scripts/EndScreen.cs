using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public string gameScene; //Name of the game
    public string menuScene; //The scene the menu is in
    AudioManager manager;

    public void RestartGame()
    {
        manager = FindObjectOfType<AudioManager>();
        manager.StopAll();
        SceneManager.LoadScene(gameScene);//loads the game scene
        Cursor.visible = false;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);//loads the menu scene
        Cursor.visible = true;
    }
}
