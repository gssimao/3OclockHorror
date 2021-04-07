using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLadder : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Inventory Pinv;
    [SerializeField]
    GameObject inCanv;
    [SerializeField]
    invInput Listener;
    [SerializeField]
    Item brokenLadder;
    [SerializeField]
    SpriteRenderer sprite;

    bool ladTaken;
    float dist;
    float index;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        index += Time.deltaTime;

        if(dist <= 0.7f && ladTaken == false)
        {
            Listener.isFocus = false;

            if(uControls.Player.Interact.triggered)
            {
                inCanv.SetActive(true);
                Pinv.AddItem(brokenLadder);
                inCanv.SetActive(false);

                sprite.sprite = null;
                ladTaken = true;
            }
        }
    }
}
