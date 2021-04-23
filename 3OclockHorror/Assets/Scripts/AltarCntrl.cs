using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarCntrl : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject rightEnding;
    [SerializeField]
    GameObject noDiamond;
    [SerializeField]
    GameObject Diamond;
    [SerializeField]
    invInput Listener;

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
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (dist < 1.0f)
        {
            //Listener.isFocus = false;
            if (uControls.Player.Interact.triggered)
            {
                rightEnding.SetActive(true);

                if (player.GetComponent<PlayerMovement>().leftSide)
                {
                    Diamond.SetActive(true);
                }
                else
                {
                    noDiamond.SetActive(true);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, 1.0f);
    }
}
