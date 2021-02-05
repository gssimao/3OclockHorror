using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mMenuScene;
    public AudioManager menuAudio;
    public Material material;

    public float amplitude = 1.4f;
    public float omega = .3f;
    float index;
    float wave;


    void Awake()
    {
        menuAudio.Play("Theme");
    }
    private void Update()
    {
        index += Time.deltaTime;
        wave = Mathf.Abs(amplitude * Mathf.Sin(omega * index));
        material.SetFloat("_LightWave", wave);
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
