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
    GameObject BTPuzzle;
    [SerializeField]
    GameObject KeyPopUp;
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
                if (!EntrancePuzzle.solved)
                {
                    BTPuzzle.SetActive(true);
                }
                else if(!plyinv.ContainsItem(key))
                {
                    KeyPopUp.SetActive(true);
                }
                if (EntrancePuzzle.solved && plyinv.ContainsItem(key))
                {
                    Enterthehouse();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }

    public void Enterthehouse()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    public IEnumerator LoadYourAsyncScene()
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
