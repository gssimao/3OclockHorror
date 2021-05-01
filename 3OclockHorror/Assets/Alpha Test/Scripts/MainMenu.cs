using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string mMenuScene;
    AudioManager menuAudio;
    public Material material;
    public Image Background;
    public Image effect1;
    public Image effect2;

    public float amplitude = 1.4f;
    public float omega = .3f;
    /*    float index;
        float wave;*/

    [SerializeField]
    Animator Fade;
    Scene currentScene;

    void Awake()
    {
        menuAudio = FindObjectOfType<AudioManager>();
        menuAudio.StopAll();
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
        ChangeScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    public IEnumerator LoadYourAsyncScene()
    {
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("fadeOut");

        currentScene = SceneManager.GetActiveScene();

        yield return new WaitForSeconds(0.5f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mMenuScene, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)// Runs this code until the next scene is done loading
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(currentScene);
    }
}
