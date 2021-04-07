using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCntrl : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject EndCanv;

    public invInput Listener;
    bool diamondTaken = false;

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
    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf && !diamondTaken)
        {
            float dist = Vector2.Distance(this.gameObject.transform.position, player.transform.position);
            if(dist < 1)
            {
                //Listener.isFocus = false;
                if (uControls.Player.Interact.triggered)
                {
                    diamondTaken = true;
                    EndCanv.SetActive(true);
                }       
            }
            player.GetComponent<PlayerMovement>().leftSide = true;
        }        
    }
}
