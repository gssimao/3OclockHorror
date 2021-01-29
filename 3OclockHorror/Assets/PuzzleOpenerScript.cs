using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOpenerScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject Puzzle;
    [SerializeField]
    float range;

    public invInput listener;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if(dist <= range)
        {
            listener.enabled = false;
            if (Input.GetKeyDown("e") && !Puzzle.activeSelf)
            {
                Puzzle.SetActive(true);
            }
            else if(Input.GetKeyDown("e") && Puzzle.activeSelf)
            {
                Puzzle.SetActive(false);
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
}
