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
    AudioManager manager;

    public float dist;
    float range = 0.5f;

    UniversalControls uControls;
    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();
    }
    private void OnDisable()
    {
        uControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if (dist <= range)
        {
            //Listener.isFocus = false;
            if (uControls.Player.Interact.triggered)
            {
                if (plyinv.ContainsItem(key) && EntrancePuzzle.solved)
                {
                    Debug.Log("This works");
                    Enterthehouse();
                }
                else
                {
                    Tooltip.Message = "Hmmm, looks like I need a key of some sort?";
                }
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

        yield return new WaitForSeconds(Fade.GetCurrentAnimatorStateInfo(0).length);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)// Runs this code until the next scene is done loading
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(currentScene);
    }
}
