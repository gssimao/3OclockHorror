using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheHouse : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    HuntCheckSolved EntrancePuzzle;
    [SerializeField]
    Inventory plyinv;
    Scene currentScene;
    [SerializeField]
    string sceneName; // name of scene to transfer to
    [SerializeField]
    Animator Fade;
    [SerializeField]
    invInput Listener;
    [SerializeField]
    Item key;
    [SerializeField]
    Tooltip tooltipScript;

    public float dist;
    float range = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if (dist <= range)
        {
            Listener.enabled = false;
            if (Input.GetKeyDown("e"))
            {
                if (plyinv.ContainsItem(key) && EntrancePuzzle.solved)
                {
                    Debug.Log("This works");
                    Enterthehouse();
                }
                else
                {
                    tooltipScript.TimedMessage = "Hmmm, looks like I need a key of some sort?";
                }
            }
        }

        Listener.enabled = true;

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
