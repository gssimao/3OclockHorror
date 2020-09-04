using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mMenuScene;
    public AudioManager menuAudio;

    void Awake()
    {
        menuAudio.Play("wind");
    }

   public void PlayGame()
    {
        SceneManager.LoadScene(mMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
