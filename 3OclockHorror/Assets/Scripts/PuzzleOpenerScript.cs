using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleOpenerScript : MonoBehaviour
{
    public sendMessage CoinPuzzleIntroMessage;
    public sendMessage CoinPuzzleReminder;
    public sendMessage PhotoPuzzleIntroMessageNoPhotos;
    public sendMessage PhotoPuzzleIntroMessageWithPhotos;
    public sendMessage PhotoPuzzleMessageAllPhotosFound;
    public bool allPhotoFounds = false;
    public bool havePhoto = false;
    bool reminder = false;
    [SerializeField]
    bool coinPuzzle = false;
    [SerializeField]
    bool PhotoPuzzle = false;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Inventory plyInv;
    [SerializeField]
    GameObject Puzzle;
    [SerializeField]
    TaskListTracker taskManager;
    [SerializeField]
    List<Item> coins;
    [SerializeField]
    float range;
    [SerializeField]
    GameObject invCan;
    [SerializeField]
    GameObject coinCanv;

    [Space]
    [SerializeField]
    string TaskString;

    public invInput listener;

    AudioManager manager;
    float dist;
    bool canvasActive = false;
    bool havCoins = false;
    bool opened = false;
    

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

        if(dist <= range)
        {
            //listener.isFocus = false;
            if (uControls.Player.Interact.triggered)
            {
                if (!opened)
                {
                    if (coinPuzzle)
                    {
                        coinCanv.SetActive(true);
                    }

                    TaskString = "\n " + TaskString;
                    taskManager.updateList(TaskString);
                    opened = true;
                }
                if (!coinPuzzle || havCoins)
                {
                    OpenInventoryToggle();
                }
                else
                {
                   if(plyInv.ContainsItem(coins[0]) && plyInv.ContainsItem(coins[1]) && plyInv.ContainsItem(coins[2]) && plyInv.ContainsItem(coins[3]))
                   {
                        havCoins = true;
                        OpenInventoryToggle();

                         invCan.SetActive(true);
                         plyInv.RemoveItem(coins[0]);
                         plyInv.RemoveItem(coins[1]);
                         plyInv.RemoveItem(coins[2]);
                         plyInv.RemoveItem(coins[3]);
                         invCan.SetActive(false);
                          //taskManager.updateList("\n - I have to get the coins in their matching slots, but how?");
                   }
                   else
                    {
                        if(!reminder)
                        {
                            CoinPuzzleIntroMessage.TriggerMessage();
                            reminder = true;
                        }
                        else
                        {
                            CoinPuzzleReminder.TriggerMessage();
                        }
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }

    void OpenInventoryToggle()
    {
        if (!canvasActive)
        {
            Puzzle.SetActive(true);
            canvasActive = true;
        }
        else
        {
            Puzzle.SetActive(false);
            canvasActive = false;
            if (PhotoPuzzle && allPhotoFounds == false)
            {
                if (havePhoto)
                {
                    PhotoPuzzleIntroMessageWithPhotos.TriggerMessage();
                }
                else
                {
                    PhotoPuzzleIntroMessageNoPhotos.TriggerMessage();
                }
                PhotoPuzzle = false;
            }
            if(allPhotoFounds)
            {
                PhotoPuzzleMessageAllPhotosFound.TriggerMessage();
            }
        }

    }
}
