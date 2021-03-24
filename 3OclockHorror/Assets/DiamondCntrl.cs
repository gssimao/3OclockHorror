using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCntrl : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject EndCanv;

    bool diamondTaken = false;


    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf && !diamondTaken)
        {
            float dist = Vector2.Distance(this.gameObject.transform.position, player.transform.position);
            if(dist < 1)
            {
                diamondTaken = true;
                EndCanv.SetActive(true);
            }

            player.GetComponent<PlayerMovement>().leftSide = true;
        }        
    }
}
