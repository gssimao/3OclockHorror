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
        menuAudio.Play("Theme");
    }

   public void PlayGame()
    {
        menuAudio.Stop("Theme");
        SceneManager.LoadScene(mMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
