using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheHouse : MonoBehaviour
{
    [SerializeField]
    HuntCheckSolved EntrancePuzzle;
    [SerializeField]
    GameObject player;
    Scene currentScene;
    [SerializeField]
    string sceneName; // name of scene to transfer to
    [SerializeField]
    Animator Fade;
    [SerializeField]
    invInput Listener;

    float dist;
    float range = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if(EntrancePuzzle.solved)
        {

        }

        if (dist <= range)
        {
            if (Input.GetKeyDown("e"))
            {
                Listener.enabled = false;
                Enterthehouse();
            }
        }

        if (Fade != null)
        {
            if (Fade.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Fade.gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }

    void Enterthehouse()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("fadeOut");

        currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //SceneManager.MoveGameObjectToScene(Instance, SceneManager.GetSceneByName(sceneName));

        SceneManager.UnloadSceneAsync(currentScene);
    }
}
