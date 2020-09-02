using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public string gameScene;
    public string menuScene;

    public void RestartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
