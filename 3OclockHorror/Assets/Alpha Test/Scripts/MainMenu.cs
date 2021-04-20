using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string mMenuScene;
    public AudioManager menuAudio;
    public Material material;
    public Image Background;
    public Image effect1;
    public Image effect2;

    public float amplitude = 1.4f;
    public float omega = .3f;
/*    float index;
    float wave;*/


    void Awake()
    {
        menuAudio.Play("Theme", false);
    }
    public void FadeBackground()
    {
        LeanTween.alpha(Background.rectTransform, 0f, 1f);
        LeanTween.alpha(effect1.rectTransform, 0f, 1f);
        LeanTween.alpha(effect2.rectTransform, 0f, 1f);
    }
    private void Update()
    {
        if(menuAudio == null)
        {
            menuAudio = FindObjectOfType<AudioManager>();
        }
/*        index += Time.deltaTime;
        wave = Mathf.Abs(amplitude * Mathf.Sin(omega * index));
        material.SetFloat("_LightWave", wave);*/
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
