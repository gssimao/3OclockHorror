using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscCntrl : MonoBehaviour
{
    [SerializeField]
    Animator Fade;
    Scene currentScene;
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void MainMenu()
    {
        ChangeScene();
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

        //yield return new WaitForSeconds(0.7f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main_Menu_Alpha_(options)", LoadSceneMode.Additive);

        while (!asyncLoad.isDone && Fade.GetComponent<CanvasGroup>().alpha != 1)// Runs this code until the next scene is done loading
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(currentScene);
    }
}