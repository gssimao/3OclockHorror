using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLadder : MonoBehaviour
{
    [SerializeField]
    Inventory plyInv;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    Item Ladder;
    [SerializeField]
    GameObject invCanvas;
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    GameObject destination;
    [SerializeField]
    room desRoom;

    Item ladAcquired;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if(dist <= 0.5f && ladAcquired == null)
        {
            if(Input.GetKeyDown("e"))
            {
                if(plyInv.ContainsItem(Ladder))
                {
                    invCanvas.SetActive(true);
                    plyInv.RemoveItem(Ladder);
                    invCanvas.SetActive(false);

                    ladAcquired = Ladder;
                }
            }
        }

        if(ladAcquired != null)
        {
            if (dist <= 0.5f)
            {
                sprite.enabled = true;

                if (Input.GetKeyDown("e"))
                {
                    LadderFunction();
                }
            }
        }
    }

    void LadderFunction()
    {
        player.transform.position = destination.transform.position;

        player.myRoom = desRoom;
    }
}
