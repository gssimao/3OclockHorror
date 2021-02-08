using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOpenerScript : MonoBehaviour
{
    [SerializeField]
    bool coinPuzzle = false;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Inventory plyInv;
    [SerializeField]
    GameObject Puzzle;
    [SerializeField]
    List<Item> coins;
    [SerializeField]
    float range;
    [SerializeField]
    Tooltip toolTipScript;

    public invInput listener;

    AudioManager manager;
    float dist;
    bool canvasActive = false;
    bool havCoins = false;
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
            listener.enabled = false;
            if (Input.GetKeyDown("e"))
            {
                if (!coinPuzzle || havCoins)
                {
                    OpenInventoryToggle();
                }
                else
                {
                   if(plyInv.ContainsItem(coins[0]))
                   {
                        if (plyInv.ContainsItem(coins[1]))
                        {
                            if (plyInv.ContainsItem(coins[2]))
                            {
                                if (plyInv.ContainsItem(coins[3]))
                                {
                                    havCoins = true;
                                    OpenInventoryToggle();
                                }
                            }
                        }
                   }
                   else
                    {
                        toolTipScript.TimedMessage = "I need four coins";
                    }
                }
            }
        }
        else
        {
            if (listener != null)
            {
                listener.enabled = true;
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
        }

    }
}
