using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLadder : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Inventory PInv;
    [SerializeField]
    GameObject invCanv;
    [SerializeField]
    Item brokenLadder;
    [SerializeField]
    invInput Listener;
    [SerializeField]
    SpriteRenderer sprite;

    float dist;
    bool ladTaken = false;
    float index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        index += Time.deltaTime;

        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if(dist <= 0.7f && ladTaken == false)
        {
            Listener.isFocus = false;

            //sprite.color.a = Mathf.Abs(Mathf.Sin(index));
            if(dist <= 0.5f && Input.GetKeyDown("e"))
            {
                invCanv.SetActive(true);
                PInv.AddItem(brokenLadder);
                invCanv.SetActive(false);

                ladTaken = true;
                sprite.sprite = null;
            }
        }
    }
}
